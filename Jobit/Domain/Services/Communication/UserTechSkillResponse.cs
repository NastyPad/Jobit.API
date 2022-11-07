using Jobit.API.Jobit.Domain.Models.Intermediate;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class UserTechSkillResponse : BaseResponse<UserTechSkill>
{
    protected UserTechSkillResponse(UserTechSkill resource) : base(resource)
    {
    }

    protected UserTechSkillResponse(string message) : base(message)
    {
    }
}