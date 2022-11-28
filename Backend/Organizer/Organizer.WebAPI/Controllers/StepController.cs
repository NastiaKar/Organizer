using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizer.BLL.Services.Interfaces;
using Organizer.Models.DTOs.Step;

namespace Organizer.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
[ApiController]
public class StepController : ControllerBase
{
    private readonly IStepService _service;

    public StepController(IStepService service)
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
    public async Task<IActionResult> Create([FromBody] CreateStepDTO request)
    {
        try
        {
            var displayStepDto = await _service.Create(request);
            return CreatedAtAction(nameof(GetOne), new {id = displayStepDto.Id}, displayStepDto);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStepDTO request, int id)
    {
        try
        {
            var displayStepDto = await _service.Update(request, id);
            return Ok(displayStepDto);
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