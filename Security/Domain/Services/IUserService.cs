using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListUsersAsync();
    Task<User> GetByUserIdAsync(long userId);
    Task RegisterUserAsync(RegisterUserRequest registerUserRequest);
    
    
    //Create others instancies
    Task GenerateUserProfileAsync(long userId);
    Task<Object> GetUserPublicNames(long userId);
}