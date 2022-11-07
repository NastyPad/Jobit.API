using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Jobit.API.Security.Persistence.Repositories;

public class UserRespository : BaseRepository, IUserRepository
{
    public UserRespository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<User>> ListUsersAsync()
    {
        return await _databaseContext.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _databaseContext.Users.AddAsync(user);
    }

    public async Task<User> FindUserByUserIdAsync(long userId)
    {
        return await _databaseContext.Users.FindAsync(userId);
    }
    
}