using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<Job>> ListJobsAsync();
    Task AddJobAsync(Job job);
    Task<Job> FindByJobIdAsync(int jobId);
}