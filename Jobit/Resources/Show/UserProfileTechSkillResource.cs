namespace Jobit.API.Jobit.Resources;

public class UserProfileTechSkillResource
{
    public Boolean MoreThanYear { get; set; }
    public int ExperienceYears { get; set; }
    public TechSkillResource? TechSkill { get; set; }
}