using Jobit.API.Security.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Jobit.API.Jobit.Domain.Models;

public class JobRequest
{
    public long RequestId { get; set; }
    
    //Foreign Keys
    public long ApplicantId { get; set; }
    public long PostJobId { get; set; }
    
    //Relationship (Object)
    public Applicant? Applicant { get; set; }
    public PostJob? PostJob { get; set; }
    public IList<Notification> Notifications { get; set; }
}