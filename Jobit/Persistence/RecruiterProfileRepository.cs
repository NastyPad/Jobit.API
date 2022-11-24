using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class RecruiterProfileRepository : BaseRepository, IRecruiterProfileRepository
{
    public RecruiterProfileRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<RecruiterProfile>> ListRecruiterProfilesAsync()
    {
        return await _databaseContext.RecruiterProfiles.ToListAsync();
    }

    public async Task<RecruiterProfile> FindRecruiterProfileByRecruiterIdAsync(long recruiterId)
    {
        return await _databaseContext.RecruiterProfiles.FindAsync(recruiterId);
    }

    public async Task AddRecruiterProfileAsync(RecruiterProfile newRecruiterProfile)
    {
        await _databaseContext.RecruiterProfiles.AddAsync(newRecruiterProfile);
    }

    public void UpdateRecruiterProfile(RecruiterProfile updatedRecruiterProfile)
    {
        _databaseContext.RecruiterProfiles.Update(updatedRecruiterProfile);
    }

    public void DeleteRecruiterProfile(RecruiterProfile toDeleteRecruiterProfile)
    {
        _databaseContext.RecruiterProfiles.Remove(toDeleteRecruiterProfile);
    }
}