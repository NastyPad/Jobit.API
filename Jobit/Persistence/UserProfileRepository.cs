using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class UserProfileRepository: BaseRepository, IUserProfileRepository
{
    public UserProfileRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<UserProfile>> ListUserProfilesAsync()
    {
        return await _databaseContext.UserProfiles.ToListAsync();
    }

    public async Task<UserProfile> FindUserProfileByUserIdAsync(long userId)
    {
        return await _databaseContext.UserProfiles.FindAsync(userId);
    }

    public async Task AddUserProfileAsync(UserProfile newUserProfile)
    {
        await _databaseContext.UserProfiles.AddAsync(newUserProfile);
    }

    public void UpdateUserProfile(UserProfile updatedUserProfile)
    { 
        _databaseContext.UserProfiles.Update(updatedUserProfile);
    }

    public void DeleteUserProfile(UserProfile toDeleteUserProfile)
    { 
        _databaseContext.UserProfiles.Remove(toDeleteUserProfile);
    }
}