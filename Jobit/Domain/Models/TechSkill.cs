using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class TechSkill
{
    public long TechSkillId { get; set; }
    public String? TechName { get; set; }
    public String? PhotoUrl { get; set; }
    //public IList<UserProfile> UserProfiles { get; set; }
    public IList<UserProfileTechSkill> UserProfileTechSkills { get; set; }

    public void SetTechSkill(TechSkill techSkill)
    {
        TechName = techSkill.TechName;
        PhotoUrl = techSkill.PhotoUrl;
    }

    
    
}