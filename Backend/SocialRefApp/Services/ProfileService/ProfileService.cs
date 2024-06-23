using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Services.ProfileService;

public class ProfileService : IProfileService
{
    private readonly SrDevDbContext _dataContext;
    private readonly IMapper _mapper;

    public ProfileService(SrDevDbContext dataContext, IMapper mapper)
    {
        _mapper = mapper;
        _dataContext = dataContext;
    }

    //? PROCEDURE - Check if the handle is already taken
    public ServiceResponse<bool> IsHandleAlreadyExists(string profileHandle)
    {
        ServiceResponse<bool> serviceResponse = new();

        try
        {
            int isExist = 0;

            DbConnection conString = _dataContext.Database.GetDbConnection();
            using (SqlConnection con = new(conString.ConnectionString))
            {
                SqlCommand cmd = new("GetCheckExistingProfileHandle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProfileHandle", profileHandle);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    isExist = Convert.ToInt32(rdr["IsExist"]);
                }
                con.Close();
            }

            serviceResponse.Data = isExist > 0;
            serviceResponse.Success = true;
            serviceResponse.Message = "Checked";

            return serviceResponse;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;

            return serviceResponse;
        }
    }

    //?? EF - Add UserProfile Record
    public async Task<ServiceResponse<string>> AddUserProfile(UserProfileAddDto request,string userId)
    {
        ServiceResponse<string> serviceResponse = new();

        try
        {
            //? Checks if handle is already taken
            if (IsHandleAlreadyExists(request.ProfileHandle).Data)
            {
                throw new Exception("Handle Already Taken");
            }

            if(string.IsNullOrEmpty(userId)){
                throw new Exception("Invalid User");
            }

            //? Map & Set
            UserProfile userProfile = _mapper.Map<UserProfile>(request);
            userProfile.ProfileCreatedDate = DateTime.UtcNow;
            userProfile.IsActive = true;
            userProfile.UserId = userId;

            //? Add & Save to DB
            await _dataContext.UserProfiles.AddAsync(userProfile);
            await _dataContext.SaveChangesAsync();

            //? Prepare & Send Response
            serviceResponse.Message = "Saved";
            return serviceResponse;
        }
        catch (Exception ex)
        {
            //? Exception Handling
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
            serviceResponse.Data = "Unable to save";

            return serviceResponse;
        }
    }

    //? PROCEDURE - GetProfileDataByUserID
    public ServiceResponse<UserProfile> GetUserProfile(string UserId)
    {
        ServiceResponse<UserProfile> serviceResponse = new();

        try
        {
            List<UserProfile> listItem = [];

            DbConnection conString = _dataContext.Database.GetDbConnection();
            using (SqlConnection con = new(conString.ConnectionString))
            {
                SqlCommand cmd = new("GetUserProfile", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UserId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserProfile userProfile =
                        new()
                        {
                            ProfileId = Convert.ToInt32(rdr["ProfileId"]),
                            ProfileHandle = rdr["ProfileHandle"].ToString()!,
                            ProfileDescription = rdr["ProfileDescription"].ToString(),
                            ProfileCreatedDate = !string.IsNullOrEmpty(
                                rdr["ProfileCreatedDate"].ToString()
                            )
                                ? Convert.ToDateTime(rdr["ProfileCreatedDate"])
                                : null,
                            ProfileDeactivationDate = !string.IsNullOrEmpty(
                                rdr["ProfileDeactivationDate"].ToString()
                            )
                                ? Convert.ToDateTime(rdr["ProfileDeactivationDate"])
                                : null,
                            UserId = UserId,
                            IsActive = Convert.ToBoolean(rdr["IsActive"]),
                            IsLocationEnabled = Convert.ToBoolean(rdr["IsLocationEnabled"]),
                            Location = rdr["Location"].ToString(),
                        };

                    listItem.Add(userProfile);
                }
                con.Close();
            }

            serviceResponse.Data = listItem.FirstOrDefault();
            serviceResponse.Success = true;
            serviceResponse.Message = listItem.Count >= 1 ? "Received" : "No Profile Found";

            return serviceResponse;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;

            return serviceResponse;
        }
    }

    public Task<ServiceResponse<UserProfile>> UpdateUserProfile(UserProfile userProfile)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<string>> DeactivateProfile()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<string>> DeleteUserProfile()
    {
        throw new NotImplementedException();
    }
}
