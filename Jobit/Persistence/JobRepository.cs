using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class JobRepository : BaseRepository, IJobRepository
{
    public JobRepository(AppDatabaseContext databaseContext) : base(databaseContext) {}

    public async Task<IEnumerable<Job>> ListJobsAsync()
    {
        return await _databaseContext.Jobs.ToListAsync();
    }

    public async Task AddJobAsync(Job newJob)
    {
        await _databaseContext.Jobs.AddAsync(newJob);
    }

    public void UpdateJobAsync(Job updateJob)
    {
        _databaseContext.Jobs.Update(updateJob);
    }

    public void DeleteJobAsync(Job deleteJob)
    {
        _databaseContext.Jobs.Remove(deleteJob);
    }

    public async Task<Job> FindByJobIdAsync(long jobId)
    {
        return await _databaseContext.Jobs.FindAsync(jobId);
    }
}