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

public class TechSkillController: ControllerBase
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

    
    
}