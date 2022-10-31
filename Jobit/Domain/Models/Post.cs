using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Post
{
    public long PostId { get; set; }
    public string Content { get; set; }
   
    //Relationships
    public long UserId { get; set; } //Foreign Keys
    public short PostTypeId { get; set; } //Foreign Keys

    public PostType PostType;
    public User User;
}