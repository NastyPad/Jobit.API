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
[SwaggerTag("Creation, read, update and delete Educations")]
public class EducationController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IEducationService _educationService;

    public EducationController(IMapper mapper, IEducationService educationService)
    {
        _mapper = mapper;
        _educationService = educationService;
    }

    [HttpGet]
    public async Task<IEnumerable<EducationResource>> GetAllEducations()
    {
        var educations = await _educationService.ListEducationsAsync();
        var mappedEducations = _mapper.Map<IEnumerable<Education>, IEnumerable<EducationResource>>(educations);
        return mappedEducations;
    }

    [HttpGet("{educationId}")]
    public async Task<IActionResult> GetAllEducations(int educationId)
    {
        var result = await _educationService.FindEducationByEducationIdAsync(educationId);
        if (!result.Success)
            BadRequest(result.Message);
        var mappedEducation = _mapper.Map<Education, EducationResource>(result.Resource);
        return Ok(mappedEducation);
    }

    [HttpPut("{educationId}")]
    public async Task<IActionResult> PutEducation(long educationId, [FromBody, SwaggerRequestBody("Update education")] UpdatedEducationResource updatedEducation)
    {
        var educationMapped = _mapper.Map<UpdatedEducationResource, Education>(updatedEducation);
        var result = await _educationService.UpdateEducationAsync(educationId, educationMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var updatedEducationResponse = _mapper.Map<Education, EducationResource>(result.Resource);
        return Ok(updatedEducationResponse);
    }

    [HttpPost]
    public async Task<IActionResult> PostEducation([FromBody, SwaggerRequestBody("Add education")] SaveEducationResource newEducation)
    {
        var educationMapped = _mapper.Map<SaveEducationResource, Education>(newEducation);
        var result = await _educationService.AddEducationAsync(educationMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var newEducationResponse = _mapper.Map<Education, EducationResource>(result.Resource);
        return Ok(newEducationResponse);
    }

    [HttpDelete("{educationId}")]
    public async Task<IActionResult> DeleteEducation(long educationId)
    {
        var result = await _educationService.DeleteEducationAsync(educationId);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new {message = "Successfully deleted element."});
    }

}