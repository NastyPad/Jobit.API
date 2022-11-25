using AutoMapper;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Security.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public CompaniesController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllCompaniesAsync()
    {
        var companies = await _companyService.ListCompaniesAsync();
        var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
        return Ok(resources);
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody, SwaggerRequestBody("")] RegisterCompanyRequest newCompany)
    {
        var result = await _companyService.RegisterCompanyAsync(newCompany);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Company has been created." });
    }

}