using AutoMapper;
using Jobit.API.Jobit.Domain.Services.Communication.Login;
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
      var user = await _userService.GetUserByUserIdAsync(id);
      var resource = _mapper.Map<User, UserResource>(user);

      return Ok(resource);
   }

   [AllowAnonymous]
   [HttpPost]
   public async Task<IActionResult> LoginUser([FromBody, SwaggerRequestBody("")] LoginUserRequest loginUserRequest)
   {
      var result = await _userService.LoginUser(loginUserRequest);
      if (!result.Success)
         return BadRequest(new {message = "access denied", auth = false });

      var user = _userService.GetUserByUserIdAsync(result.Resource.UserId);
      
      return Ok(new {message = "access granted", auth = true, data = user });
   }
}