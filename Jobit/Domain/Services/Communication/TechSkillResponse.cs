using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class TechSkillResponse: BaseResponse<TechSkill>
{
    public TechSkillResponse(TechSkill resource) : base(resource)
    {
    }

    public TechSkillResponse(string message) : base(message)
    {
    }
}