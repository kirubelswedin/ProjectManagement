using Business.Interfaces;
using DTOs.Project;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreateProjectDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await projectService.CreateProjectAsync(dto);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return StatusCode(201, result.Message);
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var result = await projectService.GetProjectsAsync();
    if (!result.Success)
      return BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id)
  {
    var result = await projectService.GetProjectAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Result);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, [FromBody] UpdateProjectDto dto)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await projectService.UpdateProjectAsync(id, dto);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Message);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var result = await projectService.DeleteProjectAsync(id);
    if (!result.Success)
      return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

    return Ok(result.Message);
  }
}