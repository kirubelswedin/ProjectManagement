using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models.Response;
using Data.Interfaces;
using DTOs.Client;

namespace Business.Services;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;

    public async Task<ResponseResult> CreateClientAsync(CreateClientDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var clientEntity = ClientFactory.Map(dto);
            if (clientEntity == null)
                return ResponseResult.Failed("Failed to map client data");

            var createdEntity = await _clientRepository.CreateAsync(clientEntity);
            return createdEntity == null
                ? ResponseResult.Failed("Failed to create client")
                : ResponseResult.Created($"Created client: {createdEntity.Name}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to create client: {ex.Message}");
        }
    }

    public async Task<ResponseResult<IEnumerable<ClientDto>>> GetClientsAsync()
    {
        try
        {
            var entities = await _clientRepository.GetAllAsync();
            if (entities == null)
                return ResponseResult<IEnumerable<ClientDto>>.Failed("Failed to retrieve clients");

            var clients = entities.Select(ClientFactory.MapToDto);
            return ResponseResult<IEnumerable<ClientDto>>.Ok("Clients retrieved successfully", clients);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ClientDto>>.Failed($"Failed to retrieve clients: {ex.Message}");
        }
    }

    public async Task<ResponseResult<ClientDto>> GetClientAsync(int id)
    {
        try
        {
            var entity = await _clientRepository.GetAsync(c => c.Id == id);
            if (entity == null)
                return ResponseResult<ClientDto>.NotFound($"Client with id {id} not found");

            var client = ClientFactory.MapToDto(entity);
            return client == null
                ? ResponseResult<ClientDto>.Failed("Failed to map client data")
                : ResponseResult<ClientDto>.Ok("Client retrieved successfully", client);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ClientDto>.Failed($"Failed to retrieve client: {ex.Message}");
        }
    }

    public async Task<ResponseResult<ClientDto>> GetClientByNameAsync(string name)
    {
        try
        {
            var entity = await _clientRepository.GetAsync(c => c.Name.ToLower() == name.ToLower());
            if (entity == null)
                return ResponseResult<ClientDto>.NotFound($"Client with name '{name}' not found");

            var client = ClientFactory.MapToDto(entity);
            return client == null
                ? ResponseResult<ClientDto>.Failed("Failed to map client data")
                : ResponseResult<ClientDto>.Ok("Client retrieved successfully", client);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ClientDto>.Failed($"Failed to retrieve client: {ex.Message}");
        }
    }

    public async Task<ResponseResult> UpdateClientAsync(int id, UpdateClientDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var existingClient = await _clientRepository.GetAsync(c => c.Id == id);
            if (existingClient == null)
                return ResponseResult.NotFound($"Client with id {id} not found");

            var clientEntity = ClientFactory.Map(dto, id);
            if (clientEntity == null)
                return ResponseResult.Failed("Failed to map client data");

            var result = await _clientRepository.UpdateAsync(clientEntity);
            return result == null
                ? ResponseResult.Failed("Failed to update client")
                : ResponseResult.Ok($"Updated client: {result.Name}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to update client: {ex.Message}");
        }
    }

    public async Task<ResponseResult> DeleteClientAsync(int id)
    {
        try
        {
            var clientEntity = await _clientRepository.GetAsync(c => c.Id == id);
            if (clientEntity == null)
                return ResponseResult.NotFound($"Client with id {id} not found");

            var result = await _clientRepository.RemoveAsync(clientEntity);
            return result
                ? ResponseResult.Ok($"Deleted client: {clientEntity.Name}")
                : ResponseResult.Failed("Failed to delete client");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to delete client: {ex.Message}");
        }
    }
}