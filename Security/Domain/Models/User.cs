using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;

namespace Jobit.API.Security.Domain.Models;
//Models are from database!
public class User
{
    public long UserId { get; set; }
    public string? Username { get; set; }
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? Password { get; set; }
    public string? Email { get; set; }
    // public DateTime Birthday { get; set; }
    
    //Relationships
    //One to many (this class has more or same cardinality)
    //More
    public IList<Project> Projects { get; set; }
    public IList<Notification> Notifications { get; set; }
    public IList<Post> Posts { get; set; }
    public IList<JobRequest> JobRequests { get; set; }
    public IList<UserTechSkill> UserTechSkills { get; set; }
    //Same
    public IList<TechSkill> TechSkills { get; set; } // Cause by intermediate table
    
    //One to many (this class has more cardinality)
    public UserProfile UserProfile { get; set; } // 
   
}