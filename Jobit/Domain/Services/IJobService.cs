using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Services;

public interface IJobService
{
    Task<IEnumerable<Job>> ListJobsAsync();
    Task<Job> FindByJobIdAsync(int jobId);
}