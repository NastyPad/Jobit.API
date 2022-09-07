using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<Job>> ListPostsAsync();
    Task AddAsync(Job job);
    Task<Job> FindByJobIdAsync(int jobId);
}