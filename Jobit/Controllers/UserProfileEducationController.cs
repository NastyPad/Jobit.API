using AutoMapper;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Jobit.API.Jobit.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Add UserProfile Education")]
public class UserProfileEducationController: ControllerBase
{
    private readonly IUserProfileEducationService _userProfileEducationService;
    private readonly IMapper _mapper;

    public UserProfileEducationController(IUserProfileEducationService userProfileEducationService, IMapper mapper)
    {
        _userProfileEducationService = userProfileEducationService;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public async Task<IEnumerable<UserProfileEducationResource>> GetAllUserProfileEducationByUserId(long userId)
    {
        var userProfileEducations = await _userProfileEducationService.ListUserProfileEducationsByUserIdAsync(userId);
        var userProfileEducationsMapped = _mapper.Map<IEnumerable<UserProfileEducation>,  IEnumerable<UserProfileEducationResource>>(userProfileEducations);
        return userProfileEducationsMapped;
    }

    [HttpPost]
    public async Task<IActionResult> PostUserProfileEducation([FromBody, SwaggerRequestBody("")] SaveUserProfileEducation newUserProfileEducation)
    {
        var newUserProfileEducationMapped = _mapper.Map<SaveUserProfileEducation, UserProfileEducation>(newUserProfileEducation);
        var result = await _userProfileEducationService.AddUserProfileEducationAsync(newUserProfileEducationMapped);
        if (!result.Success)
            return BadRequest(result.Resource);
        var newUserProfileEducationResponse = _mapper.Map<UserProfileEducation, UserProfileEducationResource>(newUserProfileEducationMapped);
        return Ok(newUserProfileEducationResponse);
    }
    

}