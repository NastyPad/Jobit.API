using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

public class NotificationResource
{
    public long NotificationId { get; set; }
    public string? Content { get; set; }
    public DateTime NotificationDate { get; set; }
    public UserResource User { get; set; }
}