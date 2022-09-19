using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Job
{
    public string? CompanyName { get; set; }
    public long JobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }
    public double Salary { get; set; }
    public bool Available { get; set; }
    
    public int CompanyId { get; set; } //Foreign-key
    public Company Company { get; set; }
}