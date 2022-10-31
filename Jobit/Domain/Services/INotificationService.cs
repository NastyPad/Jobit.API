using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface INotificationService
{
    Task<IEnumerable<Notification>> ListNotificationAsync();
    Task<NotificationResponse> FindNotificationByNotificationId(long notificationId);
    Task<NotificationResponse> AddNotification(Notification notification);
    Task<NotificationResponse> DeleteNotification(long notificationId);
    Task<NotificationResponse> UpdateNotification(long notificationId, Notification notification);
}