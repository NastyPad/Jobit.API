using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<PostJob>> ListJobsAsync();
    Task AddJobAsync(PostJob newPostJob);
    void UpdateJobAsync(PostJob updatedPostJob);
    void DeleteJobAsync(PostJob deletePostJob);
    Task<PostJob?> FindByJobIdAsync(long jobId);
    
}