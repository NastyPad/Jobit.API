using System.Data.Entity;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;

namespace Jobit.API.Jobit.Persistence;

public class JobRepository : BaseRepository, IJobRepository
{
    public JobRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
        
    }

    public async Task<IEnumerable<Job>> ListPostsAsync()
    {
        return await databaseContext.Jobs.ToListAsync();
    }

    public async Task AddAsync(Job job)
    {
        throw new NotImplementedException();
    }

    public async Task<Job> FindByJobIdAsync(int jobId)
    {
        throw new NotImplementedException();
    }
}