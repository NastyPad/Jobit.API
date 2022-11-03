using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class TechSkill
{
    public long TechSkillId { get; set; }
    public String? TechName { get; set; }
    public String? PhotoUrl { get; set; }
    public bool MoreThanAYear { get; set; }
    public int ExperienceYears { get; set; }
    public IList<User> Users { get; set; }

}