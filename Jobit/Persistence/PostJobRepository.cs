using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class PostJobRepository : BaseRepository, IPostJobRepository
{
    public PostJobRepository(AppDatabaseContext databaseContext) : base(databaseContext) {}

    public async Task<IEnumerable<PostJob>> ListPostJobsAsync()
    {
        return await _databaseContext.Jobs.ToListAsync();
    }

    public async Task AddPostJobAsync(PostJob newPostJob)
    {
        await _databaseContext.Jobs.AddAsync(newPostJob);
    }

    public void UpdatePostJobAsync(PostJob updatePostJob)
    {
        _databaseContext.Jobs.Update(updatePostJob);
    }

    public void DeletePostJobAsync(PostJob deletePostJob)
    {
        _databaseContext.Jobs.Remove(deletePostJob);
    }

    public async Task<PostJob> FindByPostJobIdAsync(long jobId)
    {
        return await _databaseContext.Jobs.FindAsync(jobId);
    }
}