using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class UserProfileTechSkillResponse : BaseResponse<UserProfileTechSkill>
{
    public UserProfileTechSkillResponse(UserProfileTechSkill resource) : base(resource)
    {
    }

    public UserProfileTechSkillResponse(string message) : base(message)
    {
    }
    
}