using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IUserProfileRepository
{
    Task<IEnumerable<UserProfile>> ListUserProfilesAsync();
    Task<UserProfile> FindUserProfileByUserIdAsync(long userId);
    Task AddUserProfileAsync(UserProfile newUserProfile);
    void UpdateUserProfile(UserProfile updatedUserProfile);
    void DeleteUserProfile(UserProfile toDeleteUserProfile);
}