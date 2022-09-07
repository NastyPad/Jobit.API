using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Security.Domain.Models;

public class Company
{
    public int CompanyId { get; set; }
    public string? CompanyName { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoUrl { get; set;  }
    public string? CompanyEmail { get; set; }
    public string? Description { get; set; }

    public IList<Job> Jobs { get; set; }
}