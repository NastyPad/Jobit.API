using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creation, read, update Jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly IMapper _mapper;

    public JobController(IJobService jobService, IMapper mapper)
    {
        _jobService = jobService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<JobResource>> GetAllJobsAsync()
    {
        var jobs = await _jobService.ListJobsAsync();
        var resources = _mapper.Map<IEnumerable<Job>, IEnumerable<JobResource>>(jobs);
        return resources;
    }
}