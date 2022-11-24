using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IPostJobRepository
{
    Task<IEnumerable<PostJob>> ListPostJobsAsync();
    Task AddPostJobAsync(PostJob newPostJob);
    void UpdatePostJobAsync(PostJob updatedPostJob);
    void DeletePostJobAsync(PostJob deletePostJob);
    Task<PostJob?> FindByPostJobIdAsync(long jobId);
    
}