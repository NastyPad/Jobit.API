using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class PostJob
{
    //Table attributes
    //Standard
    public long PostJobId { get; set; }
    public string? JobName { get; set; }
    public string? Description { get; set; }
    public double Salary { get; set; }
    public bool Available { get; set; }

    public String? PostJobTitle { get; set; }
    public DateTime DateTime { get; set; }

    //Foreign key
    
    //Relationship
    //Foreign Key One To Many. This is lesser (one)
    public long RecruiterId { get; set; }
    public Recruiter? Recruiter { get; set; }
    //This is bigger (many)
    public IList<JobRequest>? JobRequests { get; set; }

}