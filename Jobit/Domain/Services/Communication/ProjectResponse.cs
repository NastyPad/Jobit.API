using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Shared.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services.Communication;

public class ProjectResponse : BaseResponse<Project>
{
    public ProjectResponse(Project resource) : base(resource)
    {
    }

    public ProjectResponse(string message) : base(message)
    {
    }
}