namespace Jobit.API.Security.Resources;

public class UserResource
{
    public long UserId { get; set; }
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public String? Password { get; set; }
    public string? Email { get; set; }
}