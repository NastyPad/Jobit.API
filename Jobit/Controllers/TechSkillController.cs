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
[SwaggerTag("Create, read, update and delte TechSkills")]
public class TechSkillController : ControllerBase
{
    private readonly ITechSkillService _techSkillService;
    private readonly IMapper _mapper;

    public TechSkillController(ITechSkillService techSkillService, IMapper mapper)
    {
        _techSkillService = techSkillService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TechSkillResource>> GetAllProjectAsync()
    {
        var techSKills = await _techSkillService.ListTechSkillsAsync();
        var mappedTechSkills = _mapper.Map<IEnumerable<TechSkill>, IEnumerable<TechSkillResource>>(techSKills);
        return mappedTechSkills;
    }

    [HttpPost]
    public async Task<IActionResult> PostTechSkill(
        [FromBody, SwaggerRequestBody("New TechSkill")] SaveTechSkillResource newTechSkill)
    {
        var mappedTechSkill = _mapper.Map<SaveTechSkillResource, TechSkill>(newTechSkill);
        var result = await _techSkillService.AddTechSkillAsync(mappedTechSkill);
        if (!result.Success)
            return BadRequest(result.Message);
        var techSkillResponse = _mapper.Map<TechSkill, TechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully added.", result = techSkillResponse });
    }

    [HttpDelete("{techSkillId}")]
    public async Task<IActionResult> DeleteTechSkill(long techSkillId)
    {
        var result = await _techSkillService.DeleteTechSkillAsync(techSkillId);
        if (!result.Success)
            return BadRequest(result.Message);
        var techSkillResponse = _mapper.Map<TechSkill, TechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully deleted.", result = techSkillResponse });
    }

    [HttpPut("{techSKillId}")]
    public async Task<IActionResult> PutTechSkill(long techSkillId, [FromBody, SwaggerRequestBody("Updated tech skill")] UpdateTechSkillResource updatedTechSkill)
    {
        var mappedTechSkill = _mapper.Map<UpdateTechSkillResource, TechSkill>(updatedTechSkill);
        var result = await _techSkillService.UpdateTechSkillAsync(techSkillId, mappedTechSkill);
        if (!result.Success)
            return BadRequest(result.Message);
        var techSkillResponse = _mapper.Map<TechSkill, TechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully updated.", result = techSkillResponse });
    }
}