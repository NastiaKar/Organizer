using Organizer.Models.Auth;

namespace Organizer.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(UserRegisterRequest registerUser);
    Task<AuthResult> LoginAsync(UserLoginRequest loginUser);
}