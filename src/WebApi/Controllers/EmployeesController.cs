using Business.Interfaces;
using DTOs.Employee;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController(IEmployeeService employeeService) : ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> Create(CreateEmployeeDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await employeeService.CreateEmployeeAsync(dto);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return StatusCode(201, result.Message);
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await employeeService.GetEmployeesAsync();
    if (!result.Success)
      return BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var result = await employeeService.GetEmployeeAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpGet("search/{searchTerm}")]
  public async Task<IActionResult> GetByName(string searchTerm)
  {
    var result = await employeeService.GetEmployeesByNameAsync(searchTerm);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UpdateEmployeeDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await employeeService.UpdateEmployeeAsync(id, dto);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Message);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var result = await employeeService.DeleteEmployeeAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Message);
  }
}