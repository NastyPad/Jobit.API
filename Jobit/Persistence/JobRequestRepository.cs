using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;

namespace Jobit.API.Jobit.Persistence;

public class JobRequestRepository : BaseRepository, IJobRequestRepository
{
    public JobRequestRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<JobRequest>> ListHiringUserApplicationAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<JobRequest> FindHiringUserApplicationByRequestId()
    {
        throw new NotImplementedException();
    }

    public async Task AddHiringUserApplication()
    {
        throw new NotImplementedException();
    }

    public void UpdateHiringUserApplication()
    {
        throw new NotImplementedException();
    }

    public void DeleteHiringUserApplication()
    {
        throw new NotImplementedException();
    }
}