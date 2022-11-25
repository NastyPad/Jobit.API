using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Resources;
using Jobit.API.Jobit.Services;
using Jobit.API.Security.Resources.Generate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Creation, read, update and delete Notification requests")]

public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;

    public NotificationController(INotificationService notificationService, IMapper mapper)
    {
        _notificationService = notificationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<NotificationResource>> GetAllNotificationsAsync()
    {
        var notifications = await _notificationService.ListNotificationAsync();
        var resources = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostNotificationAsync(
        [FromBody, SwaggerRequestBody("Notification Request")] SaveNotificationResource newNotification)
    {
        var newNotificationMapped = _mapper.Map<SaveNotificationResource, Notification>(newNotification);
        var result = await _notificationService.AddNotification(newNotificationMapped);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPut("{requestId}")]
    public async Task<IActionResult> PutNotificationAsync(long requestId,
        [FromBody, SwaggerRequestBody("Notification Request")] UpdateNotificationResource updateNotification)
    {
        var updatedNotificationMapped = _mapper.Map<UpdateNotificationResource, Notification>(updateNotification);
        var result = await _notificationService.UpdateNotification(requestId, updatedNotificationMapped);
        if (!result.Success)
            return BadRequest();
        return Ok(result.Resource);
    }

    [HttpDelete("{requestId}")]
    public async Task<IActionResult> PutNotificationAsync(long requestId)
    {
        var result = await _notificationService.DeleteNotification(requestId);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }
}