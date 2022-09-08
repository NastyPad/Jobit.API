using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;

namespace Jobit.API.Jobit.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _jobRepository;
    private readonly IMapper _mapper;

    public JobService(IJobRepository jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Job>> ListJobsAsync()
    {
        return await _jobRepository.ListJobsAsync();
    }

    public async Task<Job> FindByJobIdAsync(int jobId)
    {
        throw new NotImplementedException();
    }
}