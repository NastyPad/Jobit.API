using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Jobit.API.Jobit.Resources.Show;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creation, read, update Jobs")]
public class PostJobController : ControllerBase
{
    private readonly IPostJobService _postJobService;
    private readonly IMapper _mapper;

    public PostJobController(IPostJobService postJobService, IMapper mapper)
    {
        _postJobService = postJobService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PostJobResource>> GetAllJobsAsync()
    {
        var jobs = await _postJobService.ListPostJobsAsync();
        var resources = _mapper.Map<IEnumerable<PostJob>, IEnumerable<PostJobResource>>(jobs);
        return resources;
    }

    [HttpPost]
    [SwaggerResponse(200, "The operation was successful", typeof(PostJobResource))]
    [SwaggerResponse(500, "The job data is not valid")]
    public async Task<IActionResult> PostJobAsync([FromBody, SwaggerRequestBody("Job")] SavePostJobResource newPostJob)
    {
        var newJobMapped = _mapper.Map<SavePostJobResource, PostJob>(newPostJob);
        var result = await _postJobService.AddPostJobAsync(newJobMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var newJobResponse = _mapper.Map<PostJob, PostJobResource>(result.Resource);
        return Ok(newJobResponse);
    }
    
    [HttpPut("{jobId}")]
    public async Task<IActionResult> PutJobAsync(long jobId, [FromBody, SwaggerRequestBody("Updated Job")] UpdatePostJobResource updatePostJob)
    {
        var updatedJobMapped = _mapper.Map<UpdatePostJobResource, PostJob>(updatePostJob);
        var result = await _postJobService.UpdatePostJobAsync(jobId, updatedJobMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedJobResponse = _mapper.Map<PostJob, PostJobResource>(result.Resource);
        return Ok(updatedJobResponse);
    }
    
    [HttpDelete("{jobId}")]
    public async Task<IActionResult> DeleteJobAsync(long jobId)
    {
        var result = await _postJobService.DeletePostJobAsync(jobId);
        if (!result.Success)
            return BadRequest(result.Message);
        var deletedJobResponse = _mapper.Map<PostJob, PostJobResource>(result.Resource);
        return Ok(deletedJobResponse);
    }
}