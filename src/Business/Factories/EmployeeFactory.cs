using Data.Entities;
using DTOs.Employee;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static EmployeeEntity? Map(CreateEmployeeDto? dto)
    {
        if (dto == null) return null;

        return new EmployeeEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            HireDate = dto.HireDate,
            DepartmentId = dto.DepartmentId,
            AddressId = dto.AddressId,
            HourlyRate = dto.HourlyRate
        };
    }

    public static EmployeeEntity? Map(UpdateEmployeeDto? dto, int id)
    {
        if (dto == null) return null;

        return new EmployeeEntity
        {
            Id = id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            HireDate = dto.HireDate,
            DepartmentId = dto.DepartmentId,
            AddressId = dto.AddressId,
            HourlyRate = dto.HourlyRate
        };
    }

    public static EmployeeDto? MapToDto(EmployeeEntity? entity)
    {
        if (entity == null) return null;

        return new EmployeeDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            HireDate = entity.HireDate,
            HourlyRate = entity.HourlyRate,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,

            Department = entity.Department != null ? new DepartmentDto
            {
                Id = entity.Department.Id,
                Name = entity.Department.Name,
                Description = entity.Department.Description
            } : null,
            Address = entity.Address != null ? new AddressDto
            {
                Id = entity.Address.Id,
                Street = entity.Address.Street,
                City = entity.Address.City,
                State = entity.Address.State,
                PostalCode = entity.Address.PostalCode,
                Country = entity.Address.Country
            } : null,
        };
    }
}