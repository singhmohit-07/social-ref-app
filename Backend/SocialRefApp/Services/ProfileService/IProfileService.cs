using SocialRefApp.Entities;
using SocialRefApp.Models;

namespace SocialRefApp.Services.ProfileService;

public interface IProfileService
{
        Task<ServiceResponse<string>> AddUserProfile(UserProfileAddDto userProfile,string userId);

        ServiceResponse<UserProfile> GetUserProfile(string UserId);

        Task<ServiceResponse<UserProfile>> UpdateUserProfile(UserProfile userProfile);

        Task<ServiceResponse<string>> DeleteUserProfile();

        Task<ServiceResponse<string>> DeactivateProfile();

        ServiceResponse<bool> IsHandleAlreadyExists(string profileHandle);

}
