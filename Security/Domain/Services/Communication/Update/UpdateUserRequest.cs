using System.ComponentModel.DataAnnotations;

namespace Jobit.API.Security.Domain.Services.Communication.Update;

public class UpdateUserRequest
{
    [Required] public String? Username { get; set; }
    [Required] public String? Firstname { get; set; }
    [Required] public String? Lastname { get; set; }
    [Required] public String? Password { get; set; }
}