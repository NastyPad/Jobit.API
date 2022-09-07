using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Services.Communication;

namespace Jobit.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListUsersAsync();
    Task<User> GetByUserIdAsync(int userId);
    Task RegisterUserAsync(RegisterUserRequest registerUserRequest);
}