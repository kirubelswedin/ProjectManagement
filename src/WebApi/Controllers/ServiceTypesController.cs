using Business.Interfaces;
using DTOs.ServiceType;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceTypesController(IServiceTypeService serviceTypeService) : ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> Create(CreateServiceTypeDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await serviceTypeService.CreateServiceTypeAsync(dto);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return StatusCode(201, result.Message);
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await serviceTypeService.GetServiceTypesAsync();
    if (!result.Success)
      return BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var result = await serviceTypeService.GetServiceTypeByIdAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UpdateServiceTypeDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await serviceTypeService.UpdateServiceTypeAsync(id, dto);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Message);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var result = await serviceTypeService.DeleteServiceTypeAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Message);
  }

  [HttpPost("initialize")]
  public async Task<IActionResult> InitializeDefaults()
  {
    var result = await serviceTypeService.InitializeDefaultServiceTypesAsync();
    if (!result.Success)
      return BadRequest(result.Message);

    return Ok(result.Message);
  }
}