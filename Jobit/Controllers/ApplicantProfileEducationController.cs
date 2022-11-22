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
public class ApplicantProfileEducationController: ControllerBase
{
    private readonly IApplicantProfileEducationService _applicantProfileEducationService;
    private readonly IMapper _mapper;

    public ApplicantProfileEducationController(IApplicantProfileEducationService applicantProfileEducationService, IMapper mapper)
    {
        _applicantProfileEducationService = applicantProfileEducationService;
        _mapper = mapper;
    }

    [HttpGet("{userId}")]
    public async Task<IEnumerable<ApplicantProfileEducationResource>> GetAllUserProfileEducationByUserId(long userId)
    {
        var userProfileEducations = await _applicantProfileEducationService.ListUserProfileEducationsByUserIdAsync(userId);
        var userProfileEducationsMapped = _mapper.Map<IEnumerable<ApplicantProfileEducation>,  IEnumerable<ApplicantProfileEducationResource>>(userProfileEducations);
        return userProfileEducationsMapped;
    }

    [HttpPost]
    public async Task<IActionResult> PostUserProfileEducation([FromBody, SwaggerRequestBody("")] SaveApplicantProfileEducationResource newApplicantProfileEducationResource)
    {
        var newUserProfileEducationMapped = _mapper.Map<SaveApplicantProfileEducationResource, ApplicantProfileEducation>(newApplicantProfileEducationResource);
        var result = await _applicantProfileEducationService.AddUserProfileEducationAsync(newUserProfileEducationMapped);
        if (!result.Success)
            return BadRequest(result.Resource);
        var newUserProfileEducationResponse = _mapper.Map<ApplicantProfileEducation, ApplicantProfileEducationResource>(newUserProfileEducationMapped);
        return Ok(newUserProfileEducationResponse);
    }
    

}