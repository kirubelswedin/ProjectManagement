
using Data.Entities;
using DTOs.Project;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectEntity? Map(CreateProjectDto? dto)
    {
        if (dto == null) return null;

        return new ProjectEntity
        {
            ProjectName = dto.ProjectName,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Budget = dto.Budget,
            StatusId = dto.StatusId,
            ClientId = dto.ClientId,
            ProjectManagerId = dto.ProjectManagerId,
            ServiceTypeId = dto.ServiceTypeId
        };
    }

    public static ProjectEntity? Map(UpdateProjectDto? dto, int projectNumber)
    {
        if (dto == null) return null;

        return new ProjectEntity
        {
            ProjectName = dto.ProjectName,
            Description = dto.Description,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            Budget = dto.Budget,
            StatusId = dto.StatusId,
            ClientId = dto.ClientId,
            ProjectManagerId = dto.ProjectManagerId,
            ServiceTypeId = dto.ServiceTypeId,
            ProjectNumber = projectNumber
        };
    }

    public static ProjectEntity UpdateEntity(ProjectEntity existingEntity, UpdateProjectDto dto)
    {
        existingEntity.ProjectName = dto.ProjectName;
        existingEntity.Description = dto.Description;
        existingEntity.StartDate = dto.StartDate;
        existingEntity.EndDate = dto.EndDate;
        existingEntity.Budget = dto.Budget;
        existingEntity.StatusId = dto.StatusId;
        existingEntity.ClientId = dto.ClientId;
        existingEntity.ProjectManagerId = dto.ProjectManagerId;
        existingEntity.ServiceTypeId = dto.ServiceTypeId;
        existingEntity.UpdatedAt = DateTime.UtcNow;

        return existingEntity;
    }

    public static ProjectDto? MapToDto(ProjectEntity? entity)
    {
        if (entity == null) return null;

        return new ProjectDto
        {
            Id = entity.Id,
            ProjectNumber = entity.ProjectNumber,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,

            // Nav properties
            Status = entity.Status != null ? new StatusDto
            {
                Id = entity.Status.Id,
                Name = entity.Status.Name,
                Type = entity.Status.Type,
                Description = entity.Status.Description,
                SortOrder = entity.Status.SortOrder,
                Color = entity.Status.Color
            } : null,
            Client = entity.Client != null ? new ClientDto
            {
                Id = entity.Client.Id,
                Name = entity.Client.Name,
                CompanyName = entity.Client.CompanyName,
                Email = entity.Client.Email,
                PhoneNumber = entity.Client.PhoneNumber
            } : null,
            ProjectManager = entity.ProjectManager != null ? new EmployeeDto
            {
                Id = entity.ProjectManager.Id,
                FirstName = entity.ProjectManager.FirstName,
                LastName = entity.ProjectManager.LastName,
                Email = entity.ProjectManager.Email,
                PhoneNumber = entity.ProjectManager.PhoneNumber
            } : null,
            ServiceType = entity.ServiceType != null ? new ServiceTypeDto
            {
                Id = entity.ServiceType.Id,
                Name = entity.ServiceType.Name,
                Description = entity.ServiceType.Description,
                DefaultHourlyRate = entity.ServiceType.DefaultHourlyRate
            } : null
        };
    }
}
