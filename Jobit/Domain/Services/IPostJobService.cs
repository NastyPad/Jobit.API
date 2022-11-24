using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IPostJobService
{
    Task<IEnumerable<PostJob>> ListPostJobsAsync();
    Task<JobResponse> FindByPostJobIdAsync(int jobId);
    Task<JobResponse> AddPostJobAsync(PostJob newPostJob);
    Task<JobResponse> UpdatePostJobAsync(long jobId, PostJob updatePostJob);
    Task<JobResponse> DeletePostJobAsync(long jobId);
}