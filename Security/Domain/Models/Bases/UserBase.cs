using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Security.Domain.Models.Bases;

public class UserBase
{
    public long UserId { get; set; }
    public string? Username { get; set; }
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? Password { get; set; }
    public string? Email { get; set; }
    public String? Type { get; set; } 
    // public DateTime Birthday { get; set; }
    
    //Relationships
    //One to many (this class has more or same cardinality)
    //More
    public IList<Notification> Notifications { get; set; }
}