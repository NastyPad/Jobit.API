using System.Globalization;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListUsersAsync();
    Task AddAsync(User user);
    Task<User> FindByUserIdAsync(long userId);
}