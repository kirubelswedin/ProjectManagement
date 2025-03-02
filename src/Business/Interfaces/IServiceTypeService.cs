using Business.Models.Response;
using DTOs.ServiceType;

namespace Business.Interfaces;

public interface IServiceTypeService
{
    Task<ResponseResult> CreateServiceTypeAsync(CreateServiceTypeDto? dto);
    Task<ResponseResult<IEnumerable<ServiceTypeDto>>> GetServiceTypesAsync();
    Task<ResponseResult<ServiceTypeDto>> GetServiceTypeByIdAsync(int id);
    Task<ResponseResult> UpdateServiceTypeAsync(int id, UpdateServiceTypeDto? dto);
    Task<ResponseResult> DeleteServiceTypeAsync(int id);
    Task<ResponseResult> InitializeDefaultServiceTypesAsync();
}