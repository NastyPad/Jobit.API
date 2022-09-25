using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IJobRequestRepository
{
    Task<IEnumerable<JobRequest>> ListJobRequestAsync();
    Task<JobRequest> FindJobRequestByRequestIdAsync(long requestId);
    Task AddJobRequestAsync(JobRequest jobRequest);
    void UpdateJobRequest(JobRequest jobRequest);
    void DeleteJobRequest(JobRequest jobRequest);
}