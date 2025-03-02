using Business.Models;
using Data.Entities;
using DTOs.Client;
using DTOs.Employee;

namespace Business.Factories;

public static class ClientFactory
{
    public static ClientEntity? Map(CreateClientDto? dto)
    {
        if (dto == null) return null;

        return new ClientEntity
        {
            Name = dto.Name,
            CompanyName = dto.CompanyName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Description = dto.Description,
            AddressId = dto.AddressId
        };
    }

    public static ClientEntity? Map(UpdateClientDto? dto, int id)
    {
        if (dto == null) return null;

        return new ClientEntity
        {
            Id = id,
            Name = dto.Name,
            CompanyName = dto.CompanyName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Description = dto.Description,
            AddressId = dto.AddressId
        };
    }

    public static ClientDto? MapToDto(ClientEntity? entity)
    {
        if (entity == null) return null;

        return new ClientDto
        {
            Id = entity.Id,
            Name = entity.Name,
            CompanyName = entity.CompanyName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,

            Address = entity.Address == null ? null : new AddressDto
            {
                Id = entity.Address.Id,
                Street = entity.Address.Street,
                City = entity.Address.City,
                State = entity.Address.State,
                PostalCode = entity.Address.PostalCode,
                Country = entity.Address.Country
            }
        };
    }
}