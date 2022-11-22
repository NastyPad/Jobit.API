using Jobit.API.Jobit.Domain.Models.Bases;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class RecruiterProfile : ProfileBase
{
    //Relationship
    public long RecruiterId { get; set; } //Foreign Key
    public Recruiter Recruiter { get; set; }

    public void SetRecruiterProfile(RecruiterProfile applicantProfile)
    {
        Username = applicantProfile.Username;
        Firstname = applicantProfile.Firstname;
        Lastname = applicantProfile.Lastname;
        ProfilePhotoUrl = applicantProfile.ProfilePhotoUrl;
        Description = applicantProfile.Description;
        IsPrivate = applicantProfile.IsPrivate;
        Gender = applicantProfile.Gender;
    }
}