using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Security.Persistence.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<User>> ListAllUsersAsync()
    {
        return await _databaseContext.Users.ToListAsync();
    }

    public async Task RegisterUserAsync(User user)
    {
        await _databaseContext.Users.AddAsync(user);
    }

    public async Task<User> FindUserByUserIdAsync(long userId)
    {
        return await _databaseContext.Users.FindAsync(userId);
    }

    public void DeleteUser(User toDeleteUser)
    {
        _databaseContext.Users.Remove(toDeleteUser);
    }
}