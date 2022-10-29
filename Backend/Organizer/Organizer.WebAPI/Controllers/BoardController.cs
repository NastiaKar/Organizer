using Microsoft.AspNetCore.Mvc;
using Organizer.BLL.Services.Interfaces;
using Organizer.Models.DTOs.Board;

namespace Organizer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IBoardService _service;

    public BoardController(IBoardService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        return Ok(await _service.GetOne(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBoardDTO request)
    {
        try
        {
            var displayBoardDto = await _service.Create(request);
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
            var displayBoardDto = await _service.Update(request, id);
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
            await _service.Delete(id);
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return Ok();
    }
}