using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizer.BLL.Extensions;
using Organizer.BLL.Services.Interfaces;
using Organizer.Models.DTOs.Board;

namespace Organizer.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class UserBoardController : ControllerBase
{
    private readonly IUserBoardService _service;

    public UserBoardController(IUserBoardService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        int userId = HttpContext.GetUserId();
        return Ok(await _service.GetAll(userId));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        int userId = HttpContext.GetUserId();
        return Ok(await _service.GetOne(userId, id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBoardDTO request)
    {
        try
        {
            int userId = HttpContext.GetUserId();
            var displayBoardDto = await _service.Create(userId, request);
            return CreatedAtAction(nameof(GetOne), new {id = displayBoardDto.Id}, displayBoardDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBoardDTO request, int id)
    {
        try
        {
            int userId = HttpContext.GetUserId();
            var displayBoardDto = await _service.Update(userId, request, id);
            return Ok(displayBoardDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            int userId = HttpContext.GetUserId();
            await _service.Delete(userId, id);
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return Ok();
    }
}