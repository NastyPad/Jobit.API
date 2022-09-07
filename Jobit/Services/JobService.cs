using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class JobService :  IJobRepository
{
    public async Task<IEnumerable<Job>> ListPostsAsync()
    {
        throw new NotImplementedException();
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