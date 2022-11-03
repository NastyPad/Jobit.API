using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class UserProfile
{
    
    public String? Description { get; set; }
    public bool IsPrivate { get; set; }
    
    
    //Relationships - Foreignkey
    public long UserId { get; set; }
    
    //Relatiionships - Object
    public User User { get; set; }
}
