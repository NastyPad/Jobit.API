using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class ApplicationProfileRepository: BaseRepository, IApplicantProfileRepository
{
    public ApplicationProfileRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<ApplicantProfile>> ListUserProfilesAsync()
    {
        return await _databaseContext.ApplicantProfiles.ToListAsync();
    }

    public async Task<ApplicantProfile> FindUserProfileByUserIdAsync(long userId)
    {
        return await _databaseContext.ApplicantProfiles.FindAsync(userId);
    }

    public async Task AddApplicantProfileAsync(ApplicantProfile newApplicantProfile)
    {
        await _databaseContext.ApplicantProfiles.AddAsync(newApplicantProfile);
    }

    public void UpdateUserProfile(ApplicantProfile updatedApplicantProfile)
    { 
        _databaseContext.ApplicantProfiles.Update(updatedApplicantProfile);
    }

    public void DeleteUserProfile(ApplicantProfile toDeleteApplicantProfile)
    { 
        _databaseContext.ApplicantProfiles.Remove(toDeleteApplicantProfile);
    }
}