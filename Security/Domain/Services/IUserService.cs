using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication.Login;
using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;
using Jobit.API.Security.Domain.Services.Communication.Responses;

namespace Jobit.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListUsersAsync();
    Task<User> GetUserByUserIdAsync(long userId);
    Task RegisterUserAsync(RegisterUserRequest registerUserRequest);

    Task<UserResponse> LoginUser(LoginUserRequest loginUserRequest);
    
    //Create others instancies
    Task GenerateUserProfileAsync(long userId);
    Task<Object> GetUserPublicNames(long userId);
}