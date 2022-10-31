using Microsoft.AspNetCore.Mvc;
using Organizer.BLL.Services.Interfaces;
using Organizer.Models.Auth;

namespace Organizer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        return Ok(await _service.RegisterAsync(request));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        return Ok(await _service.LoginAsync(request));
    }
}