using System.ComponentModel.DataAnnotations;

namespace Organizer.Models.Auth;

public class UserRegisterRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}