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
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
   private readonly IUserService _userService;
   private readonly IMapper _mapper;

   public UsersController(IUserService userService, IMapper mapper)
   {
      _userService = userService;
      _mapper = mapper;
   }
   
   [AllowAnonymous]
   [HttpGet]
   public async Task<IActionResult> GetAllUsers()
   {
      var users = await _userService.ListUsersAsync();
      var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
      return Ok(resources);
   }
   
   [AllowAnonymous]
   [HttpGet("{id}")]
   public async Task<IActionResult> GetUserByIdAsync(int id)
   {
      var user = await _userService.GetByUserIdAsync(id);
      var resource = _mapper.Map<User, UserResource>(user);

      return Ok(resource);
   }
}