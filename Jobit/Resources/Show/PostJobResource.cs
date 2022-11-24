using Jobit.API.Security.Domain.Models;
using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

//This is the data where you get it.
public class PostJobResource
{
    public long PostJobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }
    public float Salary { get; set; }
    public bool Available { get; set; }
    public RecruiterPostJobResource? Recruiter { get; set; }
}