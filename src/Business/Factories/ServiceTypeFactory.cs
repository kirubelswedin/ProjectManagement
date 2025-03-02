using Business.Models;
using Data.Entities;
using DTOs.ServiceType;

namespace Business.Factories;

public static class ServiceTypeFactory
{
    public static ServiceTypeEntity? Map(CreateServiceTypeDto? dto)
    {
        if (dto == null) return null;

        return new ServiceTypeEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            DefaultHourlyRate = dto.DefaultHourlyRate
        };
    }

    public static ServiceTypeEntity? Map(UpdateServiceTypeDto? dto, int id)
    {
        if (dto == null) return null;

        return new ServiceTypeEntity
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            DefaultHourlyRate = dto.DefaultHourlyRate
        };
    }

    public static ServiceTypeEntity MapToEntity(ServiceType model)
    {
        return new ServiceTypeEntity
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            DefaultHourlyRate = model.DefaultHourlyRate
        };
    }

    public static ServiceTypeDto? MapToDto(ServiceTypeEntity? entity)
    {
        if (entity == null) return null;

        return new ServiceTypeDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            DefaultHourlyRate = entity.DefaultHourlyRate,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }

    private static ServiceTypeEntity Create(string name, string description, decimal defaultHourlyRate)
    {
        return new ServiceTypeEntity
        {
            Name = name,
            Description = description,
            DefaultHourlyRate = defaultHourlyRate
        };
    }

    public static ServiceTypeEntity UpdateEntity(ServiceTypeEntity entity, ServiceType model)
    {
        entity.Name = model.Name;
        entity.Description = model.Description;
        entity.DefaultHourlyRate = model.DefaultHourlyRate;
        entity.UpdatedAt = DateTime.UtcNow;

        return entity;
    }

    // default services
    public static IEnumerable<ServiceTypeEntity> CreateDefaultServiceTypes()
    {
        return new[]
        {
            Create("Systemutveckling", "Skräddarsydd systemutveckling för verksamhetens behov", 1300m),
            Create("Webbutveckling", "Frontend och backend utveckling av webbplatser och -applikationer", 1200m),
            Create("Förvaltning", "Löpande underhåll och förvaltning av system och webbplatser", 900m),
            Create("Projektledning", "Ledning och koordinering av digitala projekt", 1600m),
            Create("Kommunikation", "Strategi och produktion av digital kommunikation", 1100m),
            Create("Digital marknadsföring", "SEO, SEM och andra digitala marknadsföringstjänster", 1200m),
        };
    }
}