using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class NotificationRepository: BaseRepository, INotificationRepository
{
    public NotificationRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
        
    }

    public async Task<IEnumerable<Notification>> ListNotificationAsync()
    {
        return await databaseContext.Notifications.ToListAsync();
    }

    public async Task<Notification> FindNotificationByNotificationId(long notificationId)
    {
        return await databaseContext.Notifications.FindAsync(notificationId);
    }

    public async Task AddNotification(Notification notification)
    {
        await databaseContext.Notifications.AddAsync(notification);
    }

    public void DeleteNotification(Notification notification)
    {
        databaseContext.Notifications.Remove(notification);
    }

    public void UpdateNotification(Notification notification)
    {
        databaseContext.Notifications.Update(notification);
    }
}