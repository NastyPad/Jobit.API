using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<Job>> ListJobsAsync();
    Task AddJobAsync(Job newJob);
    void UpdateJobAsync(Job updatedJob);
    void DeleteJobAsync(Job deleteJob);
    Task<Job?> FindByJobIdAsync(long jobId);
    
}