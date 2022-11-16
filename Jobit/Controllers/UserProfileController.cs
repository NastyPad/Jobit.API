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
public class UserProfileController: ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IMapper _mapper;

    public UserProfileController(IUserProfileService userProfileService, IMapper mapper)
    {
        _userProfileService = userProfileService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<UserProfileResource>> GetUserProfiles()
    {
        var userProfiles = await _userProfileService.ListUserProfilesAsync();
        var mappedUserProfiles = _mapper.Map<IEnumerable<UserProfile>, IEnumerable<UserProfileResource>>(userProfiles);
        return mappedUserProfiles;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserProfileByUserId(long userId)
    {
        var userProfile = await _userProfileService.FindUserProfileByUserIdAsync(userId);
        var userProfileMapped = _mapper.Map<UserProfile, UserProfileResource>(userProfile.Resource);
        return Ok(userProfileMapped);
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> PutUserProfile(long userId, [FromBody, SwaggerRequestBody("Updated UserProfile")] UpdatedUserProfileResource updateUserProfile)
    {
        var mappedUserProfile = _mapper.Map<UpdatedUserProfileResource, UserProfile>(updateUserProfile);
        var result = await _userProfileService.UpdatedUserProfileAsync(userId, mappedUserProfile);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedUserProfileResponse = _mapper.Map<UserProfile, UserProfileResource>(result.Resource);
        return Ok(updatedUserProfileResponse);
    }
}