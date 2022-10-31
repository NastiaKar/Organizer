using Organizer.BLL.Services.Interfaces;
using Organizer.Models.Auth;

namespace Organizer.BLL.Services;

public class AuthService : IAuthService
{
    public Task<AuthResult> RegisterAsync(UserRegisterRequest registerUser)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResult> LoginAsync(UserLoginRequest loginUser)
    {
        throw new NotImplementedException();
    }
}