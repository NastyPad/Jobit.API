using AutoMapper;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("UserProfileTechSkills")]
public class UserProfileTechSkillController : ControllerBase
{
    private readonly IUserProfileTechSkillService _userProfileTechSkillService;
    private readonly IMapper _mapper;

    public UserProfileTechSkillController(IUserProfileTechSkillService userProfileTechSkillService, IMapper mapper)
    {
        _userProfileTechSkillService = userProfileTechSkillService;
        _mapper = mapper;
    }


    [HttpGet("{userId}")]
    public async Task<IActionResult> GetAllUserProfileTechSkillsByUserId(long userId)
    {
        var userProfileTechSkills = await _userProfileTechSkillService.ListUserTechSkillByUserIdAdAsync(userId);
        if (!userProfileTechSkills.Any())
            return BadRequest("User does not exist");
        return Ok(userProfileTechSkills);
    }

    [HttpPost]
    public async Task<IActionResult> PostUserProfileTechSkills([FromBody, SwaggerRequestBody("")] SaveUserProfileTechSkillResource saveUserProfileTechSkillResource)
    {
        var userProfileTechSkillMapped = _mapper.Map<SaveUserProfileTechSkillResource, UserProfileTechSkill>(saveUserProfileTechSkillResource);
        var result = await _userProfileTechSkillService.AddUserProfileTechSkillAsync(userProfileTechSkillMapped);
        if (result.Success)
            return BadRequest(result.Message);
        return Ok(result);
    }


}