namespace Jobit.API.Jobit.Resources;

public class UserTechSkillResource
{
    public long TechSkillId { get; set; }
    public long UserId { get; set; }
    public TechSkillResource? TechSkill { get; set; }
}