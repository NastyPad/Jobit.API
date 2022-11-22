using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Create and produces")]
public class RecruiterProfileController : ControllerBase
{
    private readonly IRecruiterProfileService _recruiterProfileService;
    private readonly IMapper _mapper;

    public RecruiterProfileController(IRecruiterProfileService recruiterProfileService, IMapper mapper)
    {
        _recruiterProfileService = recruiterProfileService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RecruiterProfileResource>> GetAllRecruiterProfiles()
    {
        var recruiterProfiles = await _recruiterProfileService.ListRecruiterProfilesByRecruiterIdAsync();
        var mappedRecruiterProfiles = _mapper.Map<IEnumerable<RecruiterProfile>, IEnumerable<RecruiterProfileResource>>(recruiterProfiles);
        return mappedRecruiterProfiles;
    }

    [HttpGet("{recruiterId}")]
    public async Task<IEnumerable<RecruiterProfileResource>> GetRecruiterProfileByRecruiterId(long recruiterId)
    {
        var recruiterProfiles = await _recruiterProfileService.ListRecruiterProfilesByRecruiterIdAsync();
        var mappedRecruiterProfiles = _mapper.Map<IEnumerable<RecruiterProfile>, IEnumerable<RecruiterProfileResource>>(recruiterProfiles);
        return mappedRecruiterProfiles;
    }
    
    [HttpPut("{recruiterId}")]
    public async Task<IActionResult> PutUserProfile(long recruiterId, [FromBody, SwaggerRequestBody("Updated UserProfile")] UpdateRecruiterProfileResource updateUserProfile)
    {
        var mappedRecruiterProfile = _mapper.Map<UpdateRecruiterProfileResource, RecruiterProfile>(updateUserProfile);
        var result = await _recruiterProfileService.UpdateRecruiterProfileAsync(recruiterId, mappedRecruiterProfile);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedUserProfileResponse = _mapper.Map<RecruiterProfile, RecruiterProfileResource>(result.Resource);
        return Ok(updatedUserProfileResponse);
    }

}