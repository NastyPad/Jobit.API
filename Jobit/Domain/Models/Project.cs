using System.ComponentModel.DataAnnotations.Schema;
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
    public long ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }
    
}