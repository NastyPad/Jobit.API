using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Jobit users profiles")]
public class ApplicantProfileController: ControllerBase
{
    private readonly IApplicantProfileService _applicantProfileService;
    private readonly IMapper _mapper;

    public ApplicantProfileController(IApplicantProfileService applicantProfileService, IMapper mapper)
    {
        _applicantProfileService = applicantProfileService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ApplicantProfileResource>> GetUserProfiles()
    {
        var userProfiles = await _applicantProfileService.ListUserProfilesAsync();
        var mappedUserProfiles = _mapper.Map<IEnumerable<ApplicantProfile>, IEnumerable<ApplicantProfileResource>>(userProfiles);
        return mappedUserProfiles;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserProfileByUserId(long userId)
    {
        var userProfile = await _applicantProfileService.FindUserProfileByUserIdAsync(userId);
        var userProfileMapped = _mapper.Map<ApplicantProfile, ApplicantProfileResource>(userProfile.Resource);
        return Ok(userProfileMapped);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> PutUserProfile(long userId, [FromBody, SwaggerRequestBody("Updated UserProfile")] UpdatedUserProfileResource updateUserProfile)
    {
        var mappedUserProfile = _mapper.Map<UpdatedUserProfileResource, ApplicantProfile>(updateUserProfile);
        var result = await _applicantProfileService.UpdatedUserProfileAsync(userId, mappedUserProfile);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedUserProfileResponse = _mapper.Map<ApplicantProfile, ApplicantProfileResource>(result.Resource);
        return Ok(updatedUserProfileResponse);
    }
}