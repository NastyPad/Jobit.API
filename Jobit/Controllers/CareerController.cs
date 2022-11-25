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
[SwaggerTag("Show careers")]
public class CareerController : ControllerBase
{
    private readonly ICareerService _careerService;
    private readonly IMapper _mapper;

    public CareerController(ICareerService careerService, IMapper mapper)
    {
        _careerService = careerService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<Career>> GetAllCareers()
    {
        return await _careerService.ListAllCareersAsync();
    }

    [HttpGet("{careerId}")]
    public async Task<IActionResult> GetCareerByCareerId(long careerId)
    {
        var result = await _careerService.FindCareerByCareerIdAsync(careerId);
        if (!result.Success)
            return BadRequest(result.Message);
        var careerMapped = _mapper.Map<Career, CareerResource>(result.Resource);
        return Ok(careerMapped);
    }

    [HttpPost]
    public async Task<IActionResult> PostCareer(
        [FromBody, SwaggerRequestBody("New Post Career")]
        SaveCareerResource newCareer)
    {
        var careerMapped = _mapper.Map<SaveCareerResource, Career>(newCareer);
        var result = await _careerService.AddCareerAsync(careerMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var careerResponse = _mapper.Map<Career, CareerResource>(result.Resource);
        return Ok(new { message = "Successfully added.", result = careerResponse });
    }

    [HttpPut("{careerId}")]
    public async Task<IActionResult> PutCareer(long careerId,
        [FromBody, SwaggerRequestBody("Updated Post Career")] UpdateCareerResource updatedCareer)
    {
        var careerMapped = _mapper.Map<UpdateCareerResource, Career>(updatedCareer);
        var result = await _careerService.UpdateCareerAsync(careerId, careerMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        var careerResponse = _mapper.Map<Career, CareerResource>(result.Resource);
        return Ok(new { message = "Successfully updated.", result = careerResponse });
    }

    [HttpDelete("{careerId}")]
    public async Task<IActionResult> DeleteCareer(long careerId)
    {
        var result = await _careerService.DeleteCareerAsync(careerId);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully deleted." });
    }
}