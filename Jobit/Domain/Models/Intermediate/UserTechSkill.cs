using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models.Intermediate;

public class UserTechSkill
{
    // Relationships - ForeignKeys
    public long TechSkillId;
    public long UserId;
    
    // Relationships - Objects
    public TechSkill TechSkill;
    public User User;
    public UserProfile UserProfile;
    
    public bool MoreThanAYear { get; set; }
    public int ExperienceYears { get; set; }

    public void SetUserTechSkill(UserTechSkill userTechSkill)
    {
        MoreThanAYear = userTechSkill.MoreThanAYear;
        ExperienceYears = userTechSkill.ExperienceYears;
    }
}