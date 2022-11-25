using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Security.Domain.Models;

public class Company
{
    public long CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoUrl { get; set;  }
    public string? CompanyEmail { get; set; }
    public string? Description { get; set; }

    //RelationShip
    public IList<PostJob> Jobs { get; set; }
    public IList<Recruiter> Recruiters { get; set; }
}