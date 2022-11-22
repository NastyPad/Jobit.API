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
[SwaggerTag("Recruiter Controller")]
public class RecruiterController: ControllerBase
{
    private readonly IRecruiterService _recruiterService;
    private readonly IMapper _mapper;

    public RecruiterController(IRecruiterService recruiterService, IMapper mapper)
    {
        _recruiterService = recruiterService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IEnumerable<RecruiterResource>> GetAllRecruiters()
    {
        var recruiters = await _recruiterService.ListAllRecruitersAsync();
        var mappedRecruiters = _mapper.Map<IEnumerable<Recruiter>, IEnumerable<RecruiterResource>>(recruiters);
        return mappedRecruiters;
    }

    [AllowAnonymous]
    [HttpGet("{recruiterId}")]
    public async Task<IActionResult> GetRecruiterByRecruiterId(long recruiterId)
    {
        var result = await _recruiterService.FindRecruiterByRecruiterIdAsync(recruiterId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedRecruiter = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(mappedRecruiter);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> RegisterRecruiterId([FromBody, SwaggerRequestBody("New Recruiter")] RegisterRecruiterRequest newRecruiter)
    {
        var result = await _recruiterService.RegisterRecruiterAsync(newRecruiter);
        if (!result.Success)
            return BadRequest(result.Message);
        var recruiterResponse = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(recruiterResponse);
    }

    [AllowAnonymous]
    [HttpPut("{recruiterId}")]
    public async Task<IActionResult> PutRecruiter(long recruiterId, [FromBody, SwaggerRequestBody("")] UpdateRecruiterRequest updatedRecruiter)
    {
        var mappedRecruiter = _mapper.Map<UpdateRecruiterRequest, Recruiter>(updatedRecruiter);
        var result = await _recruiterService.UpdateRecruiterAsync(recruiterId, mappedRecruiter);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResponse = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(mappedResponse);
    }

    [AllowAnonymous]
    [HttpDelete("{recruiterId}")]
    public async Task<IActionResult> DeleteRecruiter(long recruiterId)
    {
        var result = await _recruiterService.DeleteRecruiterAsync(recruiterId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResponse = _mapper.Map<Recruiter, RecruiterResource>(result.Resource);
        return Ok(mappedResponse);
    }

}