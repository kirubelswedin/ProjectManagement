using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models.Response;
using Data.Interfaces;
using DTOs.Status;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<ResponseResult> CreateStatusAsync(CreateStatusDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var exists = await _statusRepository.ExistsAsync(s => s.Name == dto.Name && s.Type == dto.Type);
            if (exists)
                return ResponseResult.Exists($"Status with name {dto.Name} already exists for type {dto.Type}");

            var entity = StatusFactory.Map(dto);
            if (entity == null)
                return ResponseResult.Failed("Failed to map status data");

            var created = await _statusRepository.CreateAsync(entity);
            return created == null
                ? ResponseResult.Failed("Failed to create status")
                : ResponseResult.Created($"Created status: {created.Name}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to create status: {ex.Message}");
        }
    }

    public async Task<ResponseResult<IEnumerable<StatusDto>>> GetStatusesAsync()
    {
        try
        {
            var entities = await _statusRepository.GetAllAsync();
            if (entities == null)
                return ResponseResult<IEnumerable<StatusDto>>.Failed("Failed to retrieve statuses");

            var statuses = entities.Select(StatusFactory.MapToDto);
            return ResponseResult<IEnumerable<StatusDto>>.Ok("Statuses retrieved successfully", statuses);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<StatusDto>>.Failed($"Failed to retrieve statuses: {ex.Message}");
        }
    }

    public async Task<ResponseResult<StatusDto>> GetStatusByIdAsync(int id)
    {
        try
        {
            var entity = await _statusRepository.GetAsync(s => s.Id == id);
            if (entity == null)
                return ResponseResult<StatusDto>.NotFound($"Status with id {id} not found");

            var status = StatusFactory.MapToDto(entity);
            return status == null
                ? ResponseResult<StatusDto>.Failed("Failed to map status data")
                : ResponseResult<StatusDto>.Ok("Status retrieved successfully", status);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<StatusDto>.Failed($"Failed to retrieve status: {ex.Message}");
        }
    }

    public async Task<ResponseResult> UpdateStatusAsync(int id, UpdateStatusDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var entity = await _statusRepository.GetAsync(s => s.Id == id);
            if (entity == null)
                return ResponseResult.NotFound($"Status with id {id} not found");

            var exists = await _statusRepository.ExistsAsync(s => s.Name == dto.Name && s.Type == dto.Type && s.Id != id);
            if (exists)
                return ResponseResult.Exists($"Status with name {dto.Name} already exists for type {dto.Type}");

            var statusEntity = StatusFactory.Map(dto, id);
            if (statusEntity == null)
                return ResponseResult.Failed("Failed to map status data");

            var updated = await _statusRepository.UpdateAsync(statusEntity);
            return updated == null
                ? ResponseResult.Failed("Failed to update status")
                : ResponseResult.Ok($"Updated status: {updated.Name}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to update status: {ex.Message}");
        }
    }

    public async Task<ResponseResult> DeleteStatusAsync(int id)
    {
        try
        {
            var entity = await _statusRepository.GetAsync(s => s.Id == id);
            if (entity == null)
                return ResponseResult.NotFound($"Status with id {id} not found");

            var result = await _statusRepository.RemoveAsync(entity);
            return result
                ? ResponseResult.Ok($"Deleted status: {entity.Name}")
                : ResponseResult.Failed("Failed to delete status");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to delete status: {ex.Message}");
        }
    }

    public async Task<ResponseResult> InitializeDefaultStatusesAsync()
    {
        try
        {
            var defaultProjectStatuses = StatusFactory.CreateDefaultProjectStatuses();
            var defaultInvoiceStatuses = StatusFactory.CreateDefaultInvoiceStatuses();

            foreach (var status in defaultProjectStatuses.Concat(defaultInvoiceStatuses))
            {
                if (!await _statusRepository.ExistsAsync(s => s.Name == status.Name && s.Type == status.Type))
                {
                    await _statusRepository.CreateAsync(status);
                }
            }
            return ResponseResult.Ok("Default statuses initialized successfully");
        }
        catch (Exception ex)
        {
            return ResponseResult.Failed($"Failed to initialize default statuses: {ex.Message}");
        }
    }
}