using Jobit.API.Security.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Jobit.API.Jobit.Domain.Models;

public class JobRequest
{
    public long RequestId { get; set; }
    
    //Foreign Keys
    public long UserId { get; set; }
    public long CompanyId { get; set; }
    public long JobId { get; set; }
    //Relationship
    public User? User { get; set; }
    public Company? Company { get; set; }
    public Job? Job { get; set; }
}