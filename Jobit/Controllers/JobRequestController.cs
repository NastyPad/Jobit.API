using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Jobit.API.Jobit.Resources.Save;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creation, read, update and delete Job requests")]
public class JobRequestController : ControllerBase
{
    private readonly IJobRequestService _jobRequestService;
    private readonly IMapper _mapper;

    public JobRequestController(IJobRequestService jobRequestService, IMapper mapper)
    {
        _jobRequestService = jobRequestService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<JobRequestResource>> GetAllJobRequestsAsync()
    {
        var jobRequests = await _jobRequestService.ListJobRequestsAsync();
        var resources = _mapper.Map<IEnumerable<JobRequest>, IEnumerable<JobRequestResource>>(jobRequests);
        return resources;
    }
    
    [HttpGet("{requestId}")]
    public async Task<JobRequestResource> GetJobRequestsAsync(long requestId)
    {
        var result = await _jobRequestService.FindJobRequestByRequestId(requestId);
        var resource = _mapper.Map<JobRequest, JobRequestResource>(result.Resource);
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostJobRequestsAsync([FromBody, SwaggerRequestBody("JobRequest")] SaveJobRequestResource newJobRequest)
    {
        var newJobRequestMapped = _mapper.Map<SaveJobRequestResource, JobRequest>(newJobRequest);
        var result = await _jobRequestService.AddJobRequestAsync(newJobRequestMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var newJobRequestResult = _mapper.Map<JobRequest, JobRequestResource>(newJobRequestMapped);
        return Ok(newJobRequestResult);

    }
    
    [HttpDelete("{requestId}")]
    public async Task<IActionResult> DeleteJobRequestsAsync(long requestId)
    {
        var result = await _jobRequestService.DeleteJobRequestAsync(requestId);
        if (!result.Success)
            return BadRequest(result.Message);
        var deletedJobRequestResult = _mapper.Map<JobRequest, JobRequestResource>(result.Resource);
        return Ok(deletedJobRequestResult);
    }
    
    [HttpPut("{requestId}")]
    public async Task<IActionResult> PutJobRequestsAsync(long requestId,  [FromBody, SwaggerRequestBody("JobRequest")] UpdateJobRequestResource updatedJobRequest)
    {
        var updateJobRequestMapped = _mapper.Map<UpdateJobRequestResource, JobRequest>(updatedJobRequest);
        var result = await _jobRequestService.UpdateJobRequestAsync(requestId, updateJobRequestMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedJobResult = _mapper.Map<JobRequest, JobRequestResource>(result.Resource);
        return Ok(updatedJobResult);
    }
}