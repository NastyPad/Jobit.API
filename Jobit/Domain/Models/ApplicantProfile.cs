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
    public Applicant? Applicant { get; set; }
    
    public ApplicantProfile(long applicantId, string? firstname, string? lastname, string? username, string? gender = "Not Defined", string? description = "", bool isPrivate = false, string? profilePhotoUrl = "") : base(firstname, lastname, username, gender, description, isPrivate, profilePhotoUrl)
    {
        ApplicantId = applicantId;
        ApplicantProfileTechSkills = new List<ApplicantProfileTechSkill>();
        ApplicantProfileEducations = new List<ApplicantProfileEducation>();
    }

    public void SetDefaultProfile()
    {
        Description = "";
        IsPrivate = false;
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
