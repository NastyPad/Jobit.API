namespace Jobit.API.Security.Domain.Models;

public class User
{
    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoUrl { get; set;  }
    public string? Email { get; set; }
    // public DateTime Birthday { get; set; }
}