using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services.Communication.Update;
using Jobit.API.Security.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Security.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Applicant Controller")]
public class ApplicantController: ControllerBase
{
    private readonly IApplicantService _applicantService;
    private readonly IMapper _mapper;

    public ApplicantController(IApplicantService applicantService, IMapper mapper)
    {
        _applicantService = applicantService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IEnumerable<ApplicantResource>> GetAllApplicants()
    {
        var applicants = await _applicantService.ListAllApplicantsAsync();
        var mappedApplicants = _mapper.Map<IEnumerable<Applicant>, IEnumerable<ApplicantResource>>(applicants);
        return mappedApplicants;
    }

    [AllowAnonymous]
    [HttpGet("{applicantId}")]
    public async Task<IActionResult> GetApplicantByApplicantId(long applicantId)
    {
        var result = await _applicantService.FindApplicantByApplicantIdAsync(applicantId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedApplicant = _mapper.Map<Applicant, ApplicantResource>(result.Resource);
        return Ok(mappedApplicant);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> RegisterApplicant([FromBody, SwaggerRequestBody("New Applicant")] RegisterApplicantRequest newApplicant)
    {
        var result = await _applicantService.RegisterApplicantAsync(newApplicant);
        if (!result.Success)
            return BadRequest(result.Message);
        var applicantResponse = _mapper.Map<Applicant, ApplicantResource>(result.Resource);
        return Ok(applicantResponse);
    }

    [AllowAnonymous]
    [HttpPut("{applicantId}")]
    public async Task<IActionResult> PutApplicant(long applicantId, [FromBody, SwaggerRequestBody("")] UpdateApplicantRequest updatedApplicant)
    {
        var mappedApplicant = _mapper.Map<UpdateApplicantRequest, Applicant>(updatedApplicant);
        var result = await _applicantService.UpdateApplicantAsync(applicantId, mappedApplicant);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResponse = _mapper.Map<Applicant, ApplicantResource>(result.Resource);
        return Ok(mappedResponse);
    }

    [AllowAnonymous]
    [HttpDelete("{applicantId}")]
    public async Task<IActionResult> DeleteApplicant(long applicantId)
    {
        var result = await _applicantService.DeleteApplicantAsync(applicantId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResponse = _mapper.Map<Applicant, ApplicantResource>(result.Resource);
        return Ok(mappedResponse);
    }

}