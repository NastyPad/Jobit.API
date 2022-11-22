using System.ComponentModel.DataAnnotations.Schema;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models.Intermediate;

public class ApplicantProfileTechSkill
{
    // Relationships - ForeignKeys
    [ForeignKey("tech_skill_id")]
    public long TechSkillId;
    [ForeignKey("user_id")]
    public long ApplicantId;
    
    // Relationships - Objects
    public TechSkill? TechSkill;
    public ApplicantProfile ApplicantProfile;
    
    public Boolean MoreThanAYear { get; set; }
    public int ExperienceYears { get; set; }

    public void SetUserProfileTechSkill(ApplicantProfileTechSkill applicantProfileTechSkill)
    {
        MoreThanAYear = applicantProfileTechSkill.MoreThanAYear;
        ExperienceYears = applicantProfileTechSkill.ExperienceYears;
    }
}