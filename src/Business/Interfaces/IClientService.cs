using Business.Models.Response;
using DTOs.Client;

namespace Business.Interfaces;

public interface IClientService
{
    Task<ResponseResult> CreateClientAsync(CreateClientDto? dto);
    Task<ResponseResult<IEnumerable<ClientDto>>> GetClientsAsync();
    Task<ResponseResult<ClientDto>> GetClientAsync(int id);
    Task<ResponseResult<ClientDto>> GetClientByNameAsync(string name);
    Task<ResponseResult> UpdateClientAsync(int id, UpdateClientDto? dto);
    Task<ResponseResult> DeleteClientAsync(int id);
}