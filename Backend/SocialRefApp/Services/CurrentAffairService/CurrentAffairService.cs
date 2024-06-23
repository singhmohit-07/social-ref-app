using System;
using SocialRefApp.Data;
using SocialRefApp.Dtos.CurrentAffairs;
using SocialRefApp.Dtos.Student;
using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Services.CurrentAffairService
{
    public class CurrentAffairService : ICurrentAffairService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public CurrentAffairService(DataContext dataContext, IMapper mapper)
        {

            _mapper = mapper;
            _dataContext = dataContext;
        }

        // public async Task<ServiceResponse<CurrentAffairsGetResponseDto>> GetCurrentAffairById(int currentAffairId)
        // {
        //     ServiceResponse<CurrentAffairsGetResponseDto> serviceResponse = new();
        //     try
        //     {

        //         CurrentAffairs? currentAffair = await _dataContext.CurrentAffairs.Where(x => x.Id == currentAffairId && x.IsActive == true).FirstOrDefaultAsync();

        //         if (currentAffair == null)
        //         {
        //             throw new Exception("No current affair found");
        //         }

        //         serviceResponse.Message = "Record found";

        //         serviceResponse.Data = _mapper.Map<CurrentAffairsGetResponseDto>(currentAffair);

        //         Student? createdBy = await _dataContext.Students.Where(x => x.UserId == currentAffair.CreatedBy).FirstOrDefaultAsync();

        //         if (createdBy != null)
        //             serviceResponse.Data.CreatedByName = string.IsNullOrEmpty(createdBy.FirstName) ? "" : createdBy.FirstName;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {

        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<List<CurrentAffairsGetResponseDto>>> GetCurrentAffairsListBySearch()
        // {
        //     ServiceResponse<List<CurrentAffairsGetResponseDto>> serviceResponse = new();

        //     try
        //     {

        //         List<CurrentAffairsGetResponseDto>? currentAffair = await _dataContext.CurrentAffairs.Where(c => c.IsActive == true).Select(s => _mapper.Map<CurrentAffairsGetResponseDto>(s)).ToListAsync();

        //         serviceResponse.Data = currentAffair;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {

        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> AddCurrentAffair(CurrentAffairsAddRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {

        //         CurrentAffairs currentAffairs = _mapper.Map<CurrentAffairs>(request);

        //         currentAffairs.CreatedBy = 1;
        //         currentAffairs.CreatedDate = DateTime.UtcNow;

        //         currentAffairs.ModifiedBy = 1;
        //         currentAffairs.ModifiedDate = DateTime.UtcNow;

        //         currentAffairs.IsActive = true;

        //         await _dataContext.CurrentAffairs.AddAsync(currentAffairs);
        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Current affair saved";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> StatusChangeCurrentAffair(CurrentAffairStatusRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         CurrentAffairs? currentAffair = await _dataContext.CurrentAffairs.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        //         if (currentAffair is null)
        //         {
        //             throw new Exception("Unable to get current affair record");
        //         }

        //         currentAffair.IsActive = request.IsActive;

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Current affair record status changed.";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> UpdateCurrentAffair(CurrentAffairUpdateRequestDto request)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         CurrentAffairs? currentAffair = await _dataContext.CurrentAffairs.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

        //         if (currentAffair is null)
        //         {
        //             throw new Exception("Unable to get current affair record");
        //         }

        //         CurrentAffairs updatedCurrentAffairs = _mapper.Map<CurrentAffairs>(request);

        //         _dataContext.CurrentAffairs.Update(updatedCurrentAffairs);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Current affair record updated.";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<List<CurrentAffairs>>> GetUserSavedCurrentAffairsBySearch(int userId)
        // {
            // ServiceResponse<List<CurrentAffairs>> serviceResponse = new();
            // try
            // {
                // List<CurrentAffairs>? currentAffairs = await _dataContext.Users.Where(x => x.UserId == userId).SelectMany(x => x.CurrentAffairs).ToListAsync();

            //     serviceResponse.Message = "Current affairs fetched.";
            //     serviceResponse.Data = currentAffairs;

            //     return serviceResponse;
            // }
            // catch (Exception ex)
            // {
            //     serviceResponse.Message = ex.Message;
            //     serviceResponse.Success = false;
            //     return serviceResponse;
            // }
        // }

        // public async Task<ServiceResponse<bool>> AddCurrentAffairsSavedByUser(int currentAffairId, int userId)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {
        //         User? user = await _dataContext.Users.Where(x => x.UserId == userId).FirstOrDefaultAsync();

        //         if (user == null)
        //         {
        //             throw new Exception("Unable to find user record");
        //         }

        //         CurrentAffairs? currentAffair = await _dataContext.CurrentAffairs.Where(x => x.Id == currentAffairId).FirstOrDefaultAsync();

        //         if (currentAffair == null)
        //         {
        //             throw new Exception("Unable to find current affair record");
        //         }

        //         currentAffair.Users = new List<User>(); // you could also do this in the constructor of Candidate
        //         currentAffair.Users.Add(user);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Current affair saved";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }

        // public async Task<ServiceResponse<bool>> RemoveCurrentAffairsSavedByUser(int currentAffairId, int userId)
        // {
        //     ServiceResponse<bool> serviceResponse = new();
        //     try
        //     {


        //         User? user = await _dataContext.Users.Where(x => x.UserId == userId).Include(x => x.CurrentAffairs).FirstOrDefaultAsync();

        //         if (user == null)
        //         {
        //             throw new Exception("Unable to find user record");
        //         }

        //         CurrentAffairs? currentAffair = await _dataContext.CurrentAffairs.Where(x => x.Id == currentAffairId).FirstOrDefaultAsync();

        //         if (currentAffair == null)
        //         {
        //             throw new Exception("Unable to find current affair record");
        //         }

        //         user?.CurrentAffairs?.Remove(currentAffair);

        //         await _dataContext.SaveChangesAsync();

        //         serviceResponse.Message = "Current affair unsaved";
        //         serviceResponse.Data = true;

        //         return serviceResponse;
        //     }
        //     catch (Exception ex)
        //     {
        //         serviceResponse.Message = ex.Message;
        //         serviceResponse.Success = false;
        //         return serviceResponse;
        //     }
        // }


    }
}

