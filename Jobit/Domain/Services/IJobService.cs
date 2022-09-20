using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IJobService
{
    Task<IEnumerable<Job>> ListJobsAsync();
    Task<JobResponse> FindByJobIdAsync(int jobId);
    Task<JobResponse> AddJobAsync(Job newJob);
    Task<JobResponse> UpdateJobAsync(long jobId, Job updateJob);
    Task<JobResponse> DeleteJobAsync(long jobId);
}