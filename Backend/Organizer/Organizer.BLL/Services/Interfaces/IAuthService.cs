using Organizer.Models.Auth;

namespace Organizer.BLL.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(UserRegisterRequest request);
    Task<AuthResult> LoginAsync(UserLoginRequest request);
}