using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IJobService
{
    Task<IEnumerable<PostJob>> ListJobsAsync();
    Task<JobResponse> FindByJobIdAsync(int jobId);
    Task<JobResponse> AddJobAsync(PostJob newPostJob);
    Task<JobResponse> UpdateJobAsync(long jobId, PostJob updatePostJob);
    Task<JobResponse> DeleteJobAsync(long jobId);
}