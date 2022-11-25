using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Security.Domain.Models.Bases;

namespace Jobit.API.Security.Domain.Models;

public class Applicant : UserBase
{
    public long ApplicantId { get; set; } //Primary Key
    //Relations
    public ApplicantProfile ApplicantProfile { get; set; } //Applicant has bigger cardinality
    public IList<Project> Projects { get; set; } //Applicant has bigger cardinality
    public IList<JobRequest> JobRequests { get; set; } //Applicant has bigger cardinality
    //One to many (this class has more cardinality)

    //Optional Relations
    public long UserId { get; set; }
    public User? User { get; set; }
    
    
    public void SetApplicant(Applicant applicant)
    {
        Username = applicant.Username;
        Firstname = applicant.Firstname;
        Lastname = applicant.Lastname;
        Password = applicant.Password;
        Email = applicant.Email;
        Type = applicant.Type;
    }
}