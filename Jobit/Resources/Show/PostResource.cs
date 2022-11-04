using Jobit.API.Security.Resources;

namespace Jobit.API.Jobit.Resources;

public class PostResource
{
    public long PostId { get; set; }
    public string? Content { get; set; }
    
    //Relationships
    public PostTypeResource PostType;
    public UserResource User;

}