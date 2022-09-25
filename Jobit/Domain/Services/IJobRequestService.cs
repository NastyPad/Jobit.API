using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IJobRequestService
{
    Task<IEnumerable<JobRequest>> ListJobRequestsAsync();
    Task<JobRequestResponse> FindJobRequestByRequestId(long jobRequestId);
    Task<JobRequestResponse> AddJobRequestAsync(JobRequest jobRequest);
    Task<JobRequestResponse> UpdateJobRequestAsync(long jobRequestId, JobRequest jobRequest);
    Task<JobRequestResponse> DeleteJobRequestAsync(long jobRequestId);
}