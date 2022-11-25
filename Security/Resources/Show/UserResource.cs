using Jobit.API.Security.Resources.Bases;

namespace Jobit.API.Security.Resources;

public class UserResource : UserBaseResource
{
    public long UserId { get; set; }
    public String? Type { get; set; }
}