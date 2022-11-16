using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Show careers")]
public class CareerController : ControllerBase
{
    private readonly Object[] Careers =
    {
        new { id = 1, name = "Software Engineer"},
        new { id = 2, name = "Informatics Engineer"},
        new { id = 3, name = "Wow"},
        new { id = 4, name = "Wow"},
        new { id = 5, name = "Wow"},
        new { id = 6, name = "Wow"},
        new { id = 7, name = "Wow"},
        new { id = 8, name = "Wow"},
        new { id = 9, name = "Wow"},
    };
    [HttpGet]
    public Task<object[]> GetAllCareers()
    {
        return Task.FromResult(Careers);
    }

}