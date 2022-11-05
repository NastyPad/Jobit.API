using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class TechSkill
{
    public long TechSkillId { get; set; }
    public String? TechName { get; set; }
    public String? PhotoUrl { get; set; }
    public IList<User> Users { get; set; }

    public void SetTechSkill(TechSkill techSkill)
    {
        TechName = techSkill.TechName;
        PhotoUrl = techSkill.PhotoUrl;
    }

    
    
}