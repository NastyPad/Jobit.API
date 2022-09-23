using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IJobRequestService
{
    Task<IEnumerable<JobRequest>> ListJobRequestsAsync();
    Task<JobRequestResponse> FindJobRequestByRequestId();
    Task<JobResponse> AddJobRequestAsync();
    Task<JobResponse> UpdateJobRequestAsync();
    Task<JobResponse> DeleteJobRequestAsync();
}