using Business.Interfaces;
using DTOs.Client;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(IClientService clientService) : ControllerBase
{
    private readonly IClientService _clientService = clientService;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClientDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _clientService.CreateClientAsync(dto);
        if (!result.Success)
            return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

        return StatusCode(201, result.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _clientService.GetClientsAsync();
        if (!result.Success)
            return BadRequest(result.Message);

        return Ok(result.Result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _clientService.GetClientAsync(id);
        if (!result.Success)
            return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

        return Ok(result.Result);
    }

    [HttpGet("byname/{customerName}")]
    public async Task<IActionResult> GetByClientName(string customerName)
    {
        var result = await _clientService.GetClientByNameAsync(customerName);
        if (!result.Success)
            return NotFound(new { ErrorMessage = result.Message });

        return Ok(result.Result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateClientDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _clientService.UpdateClientAsync(id, dto);
        if (!result.Success)
            return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

        return Ok(result.Message);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _clientService.DeleteClientAsync(id);
        if (!result.Success)
            return result.StatusCode == 404 ? NotFound(result.Message) : BadRequest(result.Message);

        return Ok(result.Message);
    }
}