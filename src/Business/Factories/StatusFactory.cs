using Data.Entities;
using DTOs.Status;

namespace Business.Factories;

public static class StatusFactory
{
    public static StatusEntity? Map(CreateStatusDto? dto)
    {
        if (dto == null) return null;

        return new StatusEntity
        {
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description,
            SortOrder = dto.SortOrder,
            Color = dto.Color
        };
    }

    public static StatusEntity? Map(UpdateStatusDto? dto, int id)
    {
        if (dto == null) return null;

        return new StatusEntity
        {
            Id = id,
            Name = dto.Name,
            Type = dto.Type,
            Description = dto.Description,
            SortOrder = dto.SortOrder,
            Color = dto.Color
        };
    }
    

    public static StatusDto? MapToDto(StatusEntity? entity)
    {
        if (entity == null) return null;

        return new StatusDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Type = entity.Type,
            Description = entity.Description,
            SortOrder = entity.SortOrder,
            Color = entity.Color,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt
        };
    }

    private static StatusEntity CreateProjectStatus(string name, string description, int sortOrder, string? color = null)
    {
        return new StatusEntity
        {
            Name = name,
            Type = "Project",
            Description = description,
            SortOrder = sortOrder,
            Color = color
        };
    }

    private static StatusEntity CreateInvoiceStatus(string name, string description, int sortOrder, string? color = null)
    {
        return new StatusEntity
        {
            Name = name,
            Type = "Invoice",
            Description = description,
            SortOrder = sortOrder,
            Color = color
        };
    }

    // default statuses 
    public static IEnumerable<StatusEntity> CreateDefaultProjectStatuses()
    {
        return new[]
        {
            CreateProjectStatus("Ej påbörjad", "Projektet har inte startats än", 1, "#gray"),
            CreateProjectStatus("Pågående", "Projektet är aktivt", 2, "#blue"),
            CreateProjectStatus("Pausad", "Projektet är tillfälligt pausat", 3, "#orange"),
            CreateProjectStatus("Avslutad", "Projektet är färdigt", 4, "#green"),
            CreateProjectStatus("Avbruten", "Projektet har avbrutits", 5, "#red")
        };
    }

    public static IEnumerable<StatusEntity> CreateDefaultInvoiceStatuses()
    {
        return new[]
        {
            CreateInvoiceStatus("Utkast", "Fakturan är under arbete", 1, "#gray"),
            CreateInvoiceStatus("Skickad", "Fakturan har skickats till kund", 2, "#blue"),
            CreateInvoiceStatus("Betald", "Fakturan är betald", 4, "#green"),
            CreateInvoiceStatus("Förfallen", "Fakturan har passerat förfallodatum", 3, "#red"),
            CreateInvoiceStatus("Makulerad", "Fakturan har makulerats", 5, "#black")
        };
    }
}