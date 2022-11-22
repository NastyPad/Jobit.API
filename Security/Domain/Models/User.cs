using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models.Bases;

namespace Jobit.API.Security.Domain.Models;
//Models are from database!
public class User : UserBase
{
    public Recruiter? Recruiter { get; set; }
    public Applicant? Applicant { get; set; }

    public User()
    {
    }

    public User(Applicant applicant)
    {
        Username = applicant.Username;
        Firstname = applicant.Firstname;
        Lastname = applicant.Lastname;
        Email = applicant.Email;
        Password = applicant.Password;
        Type = applicant.Type;
    }
    
    public User(Recruiter recruiter)
    {
        UserId = recruiter.UserId;
        Username = recruiter.Username;
        Firstname = recruiter.Firstname;
        Lastname = recruiter.Lastname;
        Email = recruiter.Email;
        Password = recruiter.Password;
        Type = recruiter.Type;
    }

    public void SetUserWithApplicant(Applicant applicant)
    {
        UserId = applicant.UserId;
        Username = applicant.Username;
        Firstname = applicant.Firstname;
        Lastname = applicant.Lastname;
        Email = applicant.Email;
        Password = applicant.Password;
        Type = applicant.Type;
    }

    public void SetUserWithRecruiter(Recruiter recruiter)
    {
        UserId = recruiter.UserId;
        Username = recruiter.Username;
        Firstname = recruiter.Firstname;
        Lastname = recruiter.Lastname;
        Email = recruiter.Email;
        Password = recruiter.Password;
        Type = recruiter.Type;
    }
    
}