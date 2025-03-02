using System.Diagnostics;
using Business.Factories;
using Business.Interfaces;
using Business.Models.Response;
using Data.Interfaces;
using DTOs.Project;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    private async Task<int> GenerateNextProjectNumberAsync()
    {   
        int maxProjectNumber = await _projectRepository.GetMaxProjectNumberAsync();
        return maxProjectNumber + 1;
    }

    public async Task<ResponseResult> CreateProjectAsync(CreateProjectDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var projectEntity = ProjectFactory.Map(dto);
            if (projectEntity == null)
                return ResponseResult.Failed("Failed to map project data");

            projectEntity.ProjectNumber = await GenerateNextProjectNumberAsync();
            var createdEntity = await _projectRepository.CreateAsync(projectEntity);

            return createdEntity == null
                ? ResponseResult.Failed("Failed to create project")
                : ResponseResult.Created($"Created project: {createdEntity.ProjectName} with number {createdEntity.ProjectNumber}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to create project: {ex.Message}");
        }
    }

    public async Task<ResponseResult<IEnumerable<ProjectDto>>> GetProjectsAsync()
    {
        try
        {
            var projectEntities = await _projectRepository.GetAllAsync();
            if (projectEntities == null)
                return ResponseResult<IEnumerable<ProjectDto>>.Failed("Failed to retrieve projects");

            var projects = projectEntities.Select(ProjectFactory.MapToDto);
            return ResponseResult<IEnumerable<ProjectDto>>.Ok("Projects retrieved successfully", projects);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<IEnumerable<ProjectDto>>.Failed($"Failed to retrieve projects: {ex.Message}");
        }
    }

    public async Task<ResponseResult<ProjectDto>> GetProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.Id == id);
            if (projectEntity == null)
                return ResponseResult<ProjectDto>.NotFound($"Project with id {id} not found");

            var project = ProjectFactory.MapToDto(projectEntity);
            return project == null
                ? ResponseResult<ProjectDto>.Failed("Failed to map project data")
                : ResponseResult<ProjectDto>.Ok("Project retrieved successfully", project);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult<ProjectDto>.Failed($"Failed to retrieve project: {ex.Message}");
        }
    }

    public async Task<ResponseResult> UpdateProjectAsync(int id, UpdateProjectDto? dto)
    {
        ArgumentNullException.ThrowIfNull(dto);
        try
        {
            var existingProject = await _projectRepository.GetAsync(p => p.Id == id);
            if (existingProject == null)
                return ResponseResult.NotFound($"Project with id {id} not found");

            // dynamically update DTO's and keep important fields
            var updatedEntity = ProjectFactory.UpdateEntity(existingProject, dto);
            var result = await _projectRepository.UpdateAsync(updatedEntity);

            return result == null
                ? ResponseResult.Failed("Failed to update project")
                : ResponseResult.Ok($"Updated project: {result.ProjectName}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to update project: {ex.Message}");
        }
    }

    public async Task<ResponseResult> DeleteProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(p => p.Id == id);
            if (projectEntity == null)
                return ResponseResult.NotFound($"Project with id {id} not found");

            var result = await _projectRepository.RemoveAsync(projectEntity);
            return result
                ? ResponseResult.Ok($"Deleted project: {projectEntity.ProjectName}")
                : ResponseResult.Failed("Failed to delete project");
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return ResponseResult.Failed($"Failed to delete project: {ex.Message}");
        }
    }
}