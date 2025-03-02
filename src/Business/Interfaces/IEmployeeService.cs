using Business.Models.Response;
using DTOs.Employee;

namespace Business.Interfaces;

public interface IEmployeeService
{
    Task<ResponseResult> CreateEmployeeAsync(CreateEmployeeDto? dto);
    Task<ResponseResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync();
    Task<ResponseResult<EmployeeDto>> GetEmployeeAsync(int id);
    Task<ResponseResult<IEnumerable<EmployeeDto>>> GetEmployeesByNameAsync(string searchTerm);
    Task<ResponseResult> UpdateEmployeeAsync(int id, UpdateEmployeeDto? dto);
    Task<ResponseResult> DeleteEmployeeAsync(int id);
}