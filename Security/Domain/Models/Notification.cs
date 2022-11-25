
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Notification
{
    //Attributes
    //Standard
    public long NotificationId { get; set; }
    public String? Content { get; set; }
    public DateTime NotificationDate { get; set; }
    //Foreign Key
    public long JobRequestId { get; set; }
    
    //Relationships (Objects)
    public JobRequest JobRequest { get; set; }
}