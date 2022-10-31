using Microsoft.AspNetCore.Mvc;
using Organizer.BLL.Services.Interfaces;
using Organizer.Models.Auth;

namespace Organizer.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest registerUser)
    {
        
        return Ok();
    }
}