using System.ComponentModel.DataAnnotations.Schema;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models.Intermediate;

public class UserProfileTechSkill
{
    // Relationships - ForeignKeys
    [ForeignKey("tech_skill_id")]
    public long TechSkillId;
    [ForeignKey("user_id")]
    public long UserId;
    
    // Relationships - Objects
    public TechSkill? TechSkill;
    public UserProfile UserProfile;
    
    public Boolean MoreThanAYear { get; set; }
    public int ExperienceYears { get; set; }

    public void SetUserProfileTechSkill(UserProfileTechSkill userProfileTechSkill)
    {
        MoreThanAYear = userProfileTechSkill.MoreThanAYear;
        ExperienceYears = userProfileTechSkill.ExperienceYears;
    }
}