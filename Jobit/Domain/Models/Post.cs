using Jobit.API.Security.Domain.Models;

namespace Jobit.API.Jobit.Domain.Models;

public class Post
{
    public long PostId { get; set; }
    public string Description { get; set; }
   
    //Relationships
    public long UserId { get; set; } //Foreign Keys
    public int PostTypeId { get; set; } //Foreign Keys

    public PostType PostType;
    public User User;
}