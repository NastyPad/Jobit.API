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

    [HttpPost]
    [SwaggerResponse(200, "The operation was successful", typeof(JobResource))]
    [SwaggerResponse(500, "The job data is not valid")]
    public async Task<IActionResult> PostJobAsync([FromBody, SwaggerRequestBody("Job")] SaveJobResource newJob)
    {
        var newJobMapped = _mapper.Map<SaveJobResource, Job>(newJob);
        var result = await _jobService.AddJobAsync(newJobMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var newJobResponse = _mapper.Map<Job, JobResource>(result.Resource);
        return Ok(newJobResponse);
    }
    
    [HttpPut("{jobId}")]
    public async Task<IActionResult> PutJobAsync(long jobId, [FromBody, SwaggerRequestBody("Updated Job")] UpdateJobResource updateJob)
    {
        var updatedJobMapped = _mapper.Map<UpdateJobResource, Job>(updateJob);
        var result = await _jobService.UpdateJobAsync(jobId, updatedJobMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedJobResponse = _mapper.Map<Job, JobResource>(result.Resource);
        return Ok(updatedJobResponse);
    }
    
    [HttpDelete("{jobId}")]
    public async Task<IActionResult> DeleteJobAsync(long jobId)
    {
        var result = await _jobService.DeleteJobAsync(jobId);
        if (!result.Success)
            return BadRequest(result.Message);
        var deletedJobResponse = _mapper.Map<Job, JobResource>(result.Resource);
        return Ok(deletedJobResponse);
    }
}