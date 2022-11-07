using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IUserProfileService
{
    Task<IEnumerable<UserProfile>> ListUserProfilesAsync();
    Task<UserProfileResponse> FindUserProfileByUserIdAsync(long userId);
    Task<UserProfileResponse> AddUserProfileAsync(UserProfile newUserProfile);
    Task<UserProfileResponse> UpdatedUserProfileAsync(long userId, UserProfile updateUserProfile);
    Task<UserProfileResponse> DeleteUserProfileAsync(long userId);

}