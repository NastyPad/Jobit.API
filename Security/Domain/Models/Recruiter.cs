using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Security.Domain.Models.Bases;

namespace Jobit.API.Security.Domain.Models;

public class Recruiter : UserBase
{
    public long RecruiterId { get; set; }
    
    //Relations
    //User
    public long UserId { get; set; }
    public User User { get; set; }
    //Recruiter
    public RecruiterProfile RecruiterProfile { get; set; }


    public void SetRecruiter(Recruiter recruiter)
    {
        Username = recruiter.Username;
        Firstname = recruiter.Firstname;
        Lastname = recruiter.Lastname;
        Password = recruiter.Password;
        Email = recruiter.Email;
        Type = recruiter.Type;
    }
}