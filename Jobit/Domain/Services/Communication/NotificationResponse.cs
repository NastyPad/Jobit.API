using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class NotificationResponse: BaseResponse<Notification>
{
    public NotificationResponse(Notification resource) : base(resource)
    {
    }

    public NotificationResponse(string message) : base(message)
    {
    }
}