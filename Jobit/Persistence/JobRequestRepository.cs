using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class JobRequestRepository : BaseRepository, IJobRequestRepository
{
    public JobRequestRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<JobRequest>> ListJobRequestAsync()
    {
        return await _databaseContext.JobRequests.ToListAsync();
    }

    public async Task<JobRequest> FindJobRequestByRequestIdAsync(long requestId)
    {
        return await _databaseContext.JobRequests.FindAsync(requestId);
    }

    public async Task AddJobRequestAsync(JobRequest jobRequest)
    {
        await _databaseContext.JobRequests.AddAsync(jobRequest);
    }

    public void UpdateJobRequest(JobRequest jobRequest)
    {
        _databaseContext.JobRequests.Update(jobRequest);
    }

    public void DeleteJobRequest(JobRequest jobRequest)
    {
        _databaseContext.JobRequests.Remove(jobRequest);
    }
}