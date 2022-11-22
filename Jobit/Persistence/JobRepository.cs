using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class JobRepository : BaseRepository, IJobRepository
{
    public JobRepository(AppDatabaseContext databaseContext) : base(databaseContext) {}

    public async Task<IEnumerable<PostJob>> ListJobsAsync()
    {
        return await _databaseContext.Jobs.ToListAsync();
    }

    public async Task AddJobAsync(PostJob newPostJob)
    {
        await _databaseContext.Jobs.AddAsync(newPostJob);
    }

    public void UpdateJobAsync(PostJob updatePostJob)
    {
        _databaseContext.Jobs.Update(updatePostJob);
    }

    public void DeleteJobAsync(PostJob deletePostJob)
    {
        _databaseContext.Jobs.Remove(deletePostJob);
    }

    public async Task<PostJob> FindByJobIdAsync(long jobId)
    {
        return await _databaseContext.Jobs.FindAsync(jobId);
    }
}