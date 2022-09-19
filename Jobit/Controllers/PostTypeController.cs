using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Jobit.Resources;
using Microsoft.AspNetCore.Authorization;
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
    //private readonly IPostTypeRepository _postTypeRepository;
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
    
    [AllowAnonymous]
    [HttpPost]
    [SwaggerResponse(200, "The operation was succesful", typeof(SavePostTypeResource))]
    [SwaggerResponse(500, "The postype data is not valid")]
    public async Task<IActionResult> PostPostTypeAsync([FromBody, SwaggerRequestBody("PostType")] SavePostTypeResource newPostType)
    {
        var postType = _mapper.Map<SavePostTypeResource, PostType>(newPostType);
        //var result = await _postTypeService.AddPostTypeAsync(postType);
        await _postTypeService.AddPostTypeAsync(postType);
        //result = await _mapper.Map<>()
        return Ok(newPostType);
    }
    
    [HttpPut("{id}")]
    public async Task<PostTypeResponse> PutPostTypeAsync(int id, [FromBody] SavePostTypeResource updatedPostType)
    {
        var updatedPostTypeMapped = _mapper.Map<SavePostTypeResource, PostType>(updatedPostType);
        return await _postTypeService.UpdatePostType(id, updatedPostTypeMapped);
    }
    
    [HttpDelete("{id}")]
    public async Task<PostTypeResponse> DeletePostTypeAsync(int id)
    {
        return await _postTypeService.DeletePostType(id);
    }
}