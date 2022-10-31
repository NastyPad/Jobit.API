using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> ListNotificationAsync();
    Task<Notification> FindNotificationByNotificationId(long notificationId);
    Task AddNotification(Notification notification);
    void DeleteNotification(Notification notification);
    void UpdateNotification(Notification notification);
}