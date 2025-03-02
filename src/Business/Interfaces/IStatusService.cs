using Business.Models.Response;
using DTOs.Status;

namespace Business.Interfaces;

public interface IStatusService
{
    Task<ResponseResult> CreateStatusAsync(CreateStatusDto? dto);
    Task<ResponseResult<IEnumerable<StatusDto>>> GetStatusesAsync();
    Task<ResponseResult<StatusDto>> GetStatusByIdAsync(int id);
    Task<ResponseResult> UpdateStatusAsync(int id, UpdateStatusDto? dto);
    Task<ResponseResult> DeleteStatusAsync(int id);
    Task<ResponseResult> InitializeDefaultStatusesAsync();
}