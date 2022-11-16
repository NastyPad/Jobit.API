using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class UserProfileEducationRepository : BaseRepository, IUserProfileEducationRepository
{
    public UserProfileEducationRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<UserProfileEducation> FindUserProfileEducationByUserProfileEducationId(long userProfileEducationId)
    {
        return await _databaseContext.UserProfileEducations.FindAsync(userProfileEducationId);
    }

    public async Task<IEnumerable<UserProfileEducation>> ListUserProfileEducations()
    {
        return await _databaseContext.UserProfileEducations.ToListAsync();
    }

    public async Task<IEnumerable<UserProfileEducation>> ListUserProfileEducationsByUserIdAsync(long userId)
    {
        return await _databaseContext.UserProfileEducations.Where(p => p.UserId == userId).ToListAsync();
    }

    public async Task AddUserProfileEducationAsync(UserProfileEducation newUserProfileEducation)
    {
        await _databaseContext.UserProfileEducations.AddAsync(newUserProfileEducation);
    }

    public void UpdateUserProfileEducation(UserProfileEducation updatedUserProfileEducation)
    {
        _databaseContext.UserProfileEducations.AddAsync(updatedUserProfileEducation);
    }

    public void DeleteUserProfileEducation(UserProfileEducation toDeleteUserProfileEducation)
    {
        _databaseContext.UserProfileEducations.Remove(toDeleteUserProfileEducation);
    }
}