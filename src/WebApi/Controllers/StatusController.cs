using Business.Interfaces;
using DTOs.Status;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController(IStatusService statusService) : ControllerBase
{
  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await statusService.GetStatusesAsync();
    if (!result.Success)
      return BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var result = await statusService.GetStatusByIdAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpPost("initialize")]
  public async Task<IActionResult> InitializeDefaults()
  {
    var result = await statusService.InitializeDefaultStatusesAsync();
    if (!result.Success)
      return BadRequest(result.Message);

    return Ok(result.Message);
  }
}