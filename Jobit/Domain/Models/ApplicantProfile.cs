using Jobit.API.Jobit.Domain.Models.Bases;
using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class ApplicantProfile : ProfileBase
{
    public IList<ApplicantProfileTechSkill> ApplicantProfileTechSkills { get; set; }
    public IList<ApplicantProfileEducation> ApplicantProfileEducations { get; set; }
    //public IList<TechSkill> TechSkills { get; set; }


    //Relationships - Foreignkey and PrimaryKey
    public long ApplicantId { get; set; }
    
    //Relatiionships - Object
    public Applicant Applicant { get; set; }


    public ApplicantProfile()
    {
    }

    public ApplicantProfile(long applicantId, String description, String profilePhotoUrl, bool isPrivate, String gender)
    {
        ProfilePhotoUrl = profilePhotoUrl;
        ApplicantId = applicantId;
        Description = description;
        IsPrivate = isPrivate;
        Gender = gender;
    }

    public ApplicantProfile(long applicantId, String? username, String? firstname, String? lastname)
    {
        ApplicantId = applicantId;
        Username = username;
        Firstname = firstname;
        Lastname = lastname;
        ProfilePhotoUrl = "";
        Description = "";
        IsPrivate = false;
        Gender = "Not Defined";
    }

    public void SetDefaultProfile()
    {
        Description = "";
        IsPrivate = true;
    }

    public void SetApplicantProfile(ApplicantProfile applicantProfile)
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
