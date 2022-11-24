using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Security.Persistence.Repositories;

public class RecruiterRepository : BaseRepository, IRecruiterRepository
{
    
    public RecruiterRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Recruiter>> ListAllRecruiterAsync()
    {
        return await _databaseContext.Recruiters.ToListAsync();
    }

    public async Task<Recruiter> FindRecruiterByRecruiterIdAsync(long recruiterId)
    {
        return await _databaseContext.Recruiters.FindAsync(recruiterId);
    }

    public async Task RegisterRecruiterAsync(Recruiter newRecruiter)
    {
        await _databaseContext.Recruiters.AddAsync(newRecruiter);
    }

    public void UpdateRecruiterAsync(Recruiter updatedRecruiter)
    {
        _databaseContext.Recruiters.Update(updatedRecruiter);
    }

    public void DeleteRecruiterAsync(Recruiter toDeleteRecruiter)
    {
        _databaseContext.Recruiters.Remove(toDeleteRecruiter);
    }
}