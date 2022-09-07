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
        return await databaseContext.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await databaseContext.Users.AddAsync(user);
    }

    public async Task<User> FindByUserIdAsync(int userId)
    {
        return (await databaseContext.Users.FindAsync(userId))!;
    }
}