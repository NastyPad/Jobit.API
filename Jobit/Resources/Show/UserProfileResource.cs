using Jobit.API.Jobit.Domain.Models.Intermediate;

namespace Jobit.API.Jobit.Resources;

public class UserProfileResource
{
    public String? Username { get; set; }
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public bool IsPrivate { get; set; }
    public String? Description { get; set; }
    public String? ProfilePhotoUrl { get; set; }
    public IList<UserTechSkillResource> UserTechSkills { get; set; }
}