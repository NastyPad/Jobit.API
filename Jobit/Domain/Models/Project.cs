using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Persistence.Repositories;

namespace Jobit.API.Jobit.Domain.Models;

public class Project
{
    public long ProjectId { get; set; }
    public string? ProjectName { get; set; }
    public string? Description { get; set; }
    public string? CodeSource { get; set; }
    public string? ProjectUrl { get; set; }
    
    //Relationships and foreing keys
    public long UserId { get; set; }
    public User User { get; set; }
    
}