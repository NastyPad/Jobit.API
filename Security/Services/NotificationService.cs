using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Jobit.Persistence;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;


namespace Jobit.API.Jobit.Services;

public class NotificationService: INotificationService
{
    private readonly IUserRepository _userRepository;
    private readonly INotificationRepository _notificationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public NotificationService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _notificationRepository = notificationRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Notification>> ListNotificationAsync()
    {
        var notifications = await _notificationRepository.ListNotificationAsync();
        var listNotificationAsync = notifications.ToList();
        return listNotificationAsync;
    }

    public async Task<NotificationResponse> FindNotificationByNotificationId(long notificationId)
    { 
        var notification = _notificationRepository.FindNotificationByNotificationId(notificationId);
        if (notification == null)
            return new NotificationResponse("Sorry notification, does not exists!");
        try
        {
            return new NotificationResponse(notification.Result);
        }
        catch (Exception exception)
        {
            return new NotificationResponse($"An error has occurred: {exception.Message}");
        }
    }

    public async  Task<NotificationResponse> AddNotification(Notification newNotification)
    {
        try
        {
            await _notificationRepository.AddNotification(newNotification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(newNotification);
        }
        catch (Exception exception)
        {
            return new NotificationResponse($"An error has occurred while trying to add new notification: {exception.Message}");
        }
    }

    public async  Task<NotificationResponse> DeleteNotification(long notificationId)
    {
        var existingNotification = await _notificationRepository.FindNotificationByNotificationId(notificationId);
        try
        {
            _notificationRepository.DeleteNotification(existingNotification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(existingNotification);
        }
        catch (Exception exception)
        {
            return new NotificationResponse($"An error has occurred while trying to delete this notification: {exception.Message}");
        }
    }

    public async  Task<NotificationResponse> UpdateNotification(long notificationId, Notification updatedNotification)
    {
        var existingNotification = await _notificationRepository.FindNotificationByNotificationId(notificationId);

        existingNotification.Content = updatedNotification.Content;
        existingNotification.NotificationDate = updatedNotification.NotificationDate;
        
        try
        {
            _notificationRepository.UpdateNotification(existingNotification);
            await _unitOfWork.CompleteAsync();
            return new NotificationResponse(existingNotification);
        }
        catch (Exception exception)
        {
            return new NotificationResponse($"An error has occurred while trying to delete this notification: {exception.Message}");
        }
    }
}