using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models.Response;
using Data.Interfaces;
using DTOs.ServiceType;

namespace Business.Services;

public class ServiceTypeService(IServiceTypeRepository serviceTypeRepository) : IServiceTypeService
{
    private readonly IServiceTypeRepository _serviceTypeRepository = serviceTypeRepository;

    public async Task<ResponseResult> CreateServiceTypeAsync(CreateServiceTypeDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var exists = await _serviceTypeRepository.ExistsAsync(s => s.Name == dto.Name);
            if (exists)
                return ResponseResult.Exists($"ServiceType with name {dto.Name} already exists");

            var entity = ServiceTypeFactory.Map(dto);
            if (entity == null)
                return ResponseResult.Failed("Failed to map service type data");

            var created = await _serviceTypeRepository.CreateAsync(entity);
            return created == null
                ? ResponseResult.Failed("Failed to create service type")
                : ResponseResult.Created($"Created service type: {created.Name}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to create service type: {ex.Message}");
        }
    }

    public async Task<ResponseResult<IEnumerable<ServiceTypeDto>>> GetServiceTypesAsync()
    {
        try
        {
            var entities = await _serviceTypeRepository.GetAllAsync();
            if (entities == null)
                return ResponseResult<IEnumerable<ServiceTypeDto>>.Failed("Failed to retrieve service types");

            var serviceTypes = entities.Select(ServiceTypeFactory.MapToDto);
            return ResponseResult<IEnumerable<ServiceTypeDto>>.Ok("Service types retrieved successfully", serviceTypes);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ServiceTypeDto>>.Failed($"Failed to retrieve service types: {ex.Message}");
        }
    }

    public async Task<ResponseResult<ServiceTypeDto>> GetServiceTypeByIdAsync(int id)
    {
        try
        {
            var entity = await _serviceTypeRepository.GetAsync(s => s.Id == id);
            if (entity == null)
                return ResponseResult<ServiceTypeDto>.NotFound($"ServiceType with id {id} not found");

            var serviceType = ServiceTypeFactory.MapToDto(entity);
            return serviceType == null
                ? ResponseResult<ServiceTypeDto>.Failed("Failed to map service type data")
                : ResponseResult<ServiceTypeDto>.Ok("Service type retrieved successfully", serviceType);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ServiceTypeDto>.Failed($"Failed to retrieve service type: {ex.Message}");
        }
    }

    public async Task<ResponseResult> UpdateServiceTypeAsync(int id, UpdateServiceTypeDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var entity = await _serviceTypeRepository.GetAsync(s => s.Id == id);
            if (entity == null)
                return ResponseResult.NotFound($"ServiceType with id {id} not found");
            
            var exists = await _serviceTypeRepository.ExistsAsync(s => s.Name == dto.Name && s.Id != id);
            if (exists)
                return ResponseResult.Exists($"ServiceType with name {dto.Name} already exists");
            
            var serviceTypeEntity = ServiceTypeFactory.Map(dto, id);
            if (serviceTypeEntity == null)
                return ResponseResult.Failed("Failed to map service type data");

            var updated = await _serviceTypeRepository.UpdateAsync(serviceTypeEntity);
            return updated == null
                ? ResponseResult.Failed("Failed to update service type")
                : ResponseResult.Ok($"Updated service type: {updated.Name}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to update service type: {ex.Message}");
        }
    }

    public async Task<ResponseResult> DeleteServiceTypeAsync(int id)
    {
        try
        {
            var entity = await _serviceTypeRepository.GetAsync(s => s.Id == id);
            if (entity == null)
                return ResponseResult.NotFound($"ServiceType with id {id} not found");

            var result = await _serviceTypeRepository.RemoveAsync(entity);
            return result
                ? ResponseResult.Ok($"Deleted service type: {entity.Name}")
                : ResponseResult.Failed("Failed to delete service type");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to delete service type: {ex.Message}");
        }
    }

    // Initialize default service types 
    public async Task<ResponseResult> InitializeDefaultServiceTypesAsync()
    {
        try
        {
            var defaultTypes = ServiceTypeFactory.CreateDefaultServiceTypes();
            foreach (var serviceType in defaultTypes)
            {
                if (!await _serviceTypeRepository.ExistsAsync(s => s.Name == serviceType.Name))
                {
                    await _serviceTypeRepository.CreateAsync(serviceType);
                }
            }
            return ResponseResult.Ok("Default service types initialized successfully");
        }
        catch (Exception ex)
        {
            return ResponseResult.Failed($"Failed to initialize default service types: {ex.Message}");
        }
    }
}