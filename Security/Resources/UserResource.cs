namespace Jobit.API.Security.Resources;

public class UserResource
{
    public UserResource()
    {
        this.UserId = 0;
        this.Username = "";
        this.Firstname = "";
        this.Lastname = "";
        this.Password = "";
        this.ProfilePhotoUrl = "";
        this.Email = "";
    }

    public int UserId { get; set; }
    public string? Username { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Password { get; set; }
    public string? ProfilePhotoUrl { get; set;  }
    public string? Email { get; set; }
    // public DateTime Birthday { get; set; }
}