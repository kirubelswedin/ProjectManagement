using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models.Response;
using Data.Interfaces;
using DTOs.Employee;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<ResponseResult> CreateEmployeeAsync(CreateEmployeeDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var employeeEntity = EmployeeFactory.Map(dto);
            if (employeeEntity == null)
                return ResponseResult.Failed("Failed to map employee data");

            var createdEntity = await _employeeRepository.CreateAsync(employeeEntity);
            return createdEntity == null
                ? ResponseResult.Failed("Failed to create employee")
                : ResponseResult.Created($"Created employee: {createdEntity.FirstName} {createdEntity.LastName}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to create employee: {ex.Message}");
        }
    }

    public async Task<ResponseResult<IEnumerable<EmployeeDto>>> GetEmployeesAsync()
    {
        try
        {
            var entities = await _employeeRepository.GetAllAsync();
            if (entities == null)
                return ResponseResult<IEnumerable<EmployeeDto>>.Failed("Failed to retrieve employees");

            var employees = entities.Select(EmployeeFactory.MapToDto);
            return ResponseResult<IEnumerable<EmployeeDto>>.Ok("Employees retrieved successfully", employees);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<EmployeeDto>>.Failed($"Failed to retrieve employees: {ex.Message}");
        }
    }

    public async Task<ResponseResult<EmployeeDto>> GetEmployeeAsync(int id)
    {
        try
        {
            // Get employee with details
            var entity = await _employeeRepository.GetWithDetailsAsync(e => e.Id == id);
            if (entity == null)
                return ResponseResult<EmployeeDto>.NotFound($"Employee with id {id} not found");

            var employee = EmployeeFactory.MapToDto(entity);
            return employee == null
                ? ResponseResult<EmployeeDto>.Failed("Failed to map employee data")
                : ResponseResult<EmployeeDto>.Ok("Employee retrieved successfully", employee);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<EmployeeDto>.Failed($"Failed to retrieve employee: {ex.Message}");
        }
    }

    public async Task<ResponseResult<IEnumerable<EmployeeDto>>> GetEmployeesByNameAsync(string searchTerm)
    {
        try
        {
            var entities = await _employeeRepository.GetAllAsync();
            if (entities == null)
                return ResponseResult<IEnumerable<EmployeeDto>>.Failed("Failed to retrieve employees");

            var searchTermLower = searchTerm.ToLower();
            var matchingEmployees = entities
                .Where(e => e.FirstName.ToLower().Contains(searchTermLower) ||
                           e.LastName.ToLower().Contains(searchTermLower))
                .Select(EmployeeFactory.MapToDto)
                .Where(e => e != null);

            if (!matchingEmployees.Any())
                return ResponseResult<IEnumerable<EmployeeDto>>.NotFound($"No employees found matching '{searchTerm}'");

            return ResponseResult<IEnumerable<EmployeeDto>>.Ok("Employees retrieved successfully", matchingEmployees);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<EmployeeDto>>.Failed($"Failed to search employees: {ex.Message}");
        }
    }

    public async Task<ResponseResult> UpdateEmployeeAsync(int id, UpdateEmployeeDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var existingEmployee = await _employeeRepository.GetWithDetailsAsync(e => e.Id == id);
            if (existingEmployee == null)
                return ResponseResult.NotFound($"Employee with id {id} not found");

            var employeeEntity = EmployeeFactory.Map(dto, id);
            if (employeeEntity == null)
                return ResponseResult.Failed("Failed to map employee data");

            var result = await _employeeRepository.UpdateAsync(employeeEntity);
            return result == null
                ? ResponseResult.Failed("Failed to update employee")
                : ResponseResult.Ok($"Updated employee: {result.FirstName} {result.LastName}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to update employee: {ex.Message}");
        }
    }

    public async Task<ResponseResult> DeleteEmployeeAsync(int id)
    {
        try
        {
            var employeeEntity = await _employeeRepository.GetAsync(e => e.Id == id);
            if (employeeEntity == null)
                return ResponseResult.NotFound($"Employee with id {id} not found");

            var result = await _employeeRepository.RemoveAsync(employeeEntity);
            return result
                ? ResponseResult.Ok($"Deleted employee: {employeeEntity.FirstName} {employeeEntity.LastName}")
                : ResponseResult.Failed("Failed to delete employee");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to delete employee: {ex.Message}");
        }
    }
}