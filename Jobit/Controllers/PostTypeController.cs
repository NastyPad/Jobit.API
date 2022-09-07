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
[SwaggerTag("Create, read, update and delete PostTypes")]
public class PostTypeController : ControllerBase
{
    private readonly IPostTypeService _postTypeService;
    private readonly IMapper _mapper;
    public PostTypeController(IPostTypeService postTypeService, IMapper mapper)
    {
        _postTypeService = postTypeService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PostTypeResource>> GetAllPostTypesAsync()
    {
        var postTypes = await _postTypeService.ListPostTypesAsync();
        var resources = _mapper.Map<IEnumerable<PostType>, IEnumerable<PostTypeResource>>(postTypes);
        return resources;
    }
}