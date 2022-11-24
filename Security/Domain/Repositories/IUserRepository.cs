using System.Globalization;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAllUsersAsync();
    Task RegisterUserAsync(User user);
    Task<User> FindUserByUserIdAsync(long userId);

    void DeleteUser(User toDeleteUser);
}