using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Security.Domain.Models;
//Models are from database!
public class User
{
    public long UserId { get; set; }
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoUrl { get; set;  }
    public string? Email { get; set; }
    // public DateTime Birthday { get; set; }
    
    //Relationships
    public IList<Project> Projects { get; set; }
    public IList<Notification> Notifications { get; set; }
    public IList<Post> Posts { get; set; }
    public IList<JobRequest> JobRequests { get; set; }
    public IList<TechSkill> TechSkills { get; set; }
    public UserProfile UserProfile { get; set; }
}