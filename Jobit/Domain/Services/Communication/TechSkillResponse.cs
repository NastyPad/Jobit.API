using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class TechSkillResponse: BaseResponse<TechSkill>
{
    protected TechSkillResponse(TechSkill resource) : base(resource)
    {
    }

    protected TechSkillResponse(string message) : base(message)
    {
    }
}