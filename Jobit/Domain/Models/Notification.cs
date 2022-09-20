
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Notification
{
    public long NotificationId { get; set; }
    public string? Content { get; set; }
    public DateTime NotificationDate { get; set; }
    //Relationships
    public long UserId { get; set; }//Foreign Key
    public User? User { get; set; }
}