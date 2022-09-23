using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IJobRequestRepository
{
    Task<IEnumerable<JobRequest>> ListHiringUserApplicationAsync();
    Task<JobRequest> FindHiringUserApplicationByRequestId();
    Task AddHiringUserApplication();
    void UpdateHiringUserApplication();
    void DeleteHiringUserApplication();
}