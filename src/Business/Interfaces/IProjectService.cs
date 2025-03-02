
using Business.Models.Response;
using DTOs.Project;


namespace Business.Interfaces;

public interface IProjectService
{
    Task<ResponseResult> CreateProjectAsync(CreateProjectDto? dto);
    Task<ResponseResult<IEnumerable<ProjectDto>>> GetProjectsAsync();
    Task<ResponseResult<ProjectDto>> GetProjectAsync(int id);
    Task<ResponseResult> UpdateProjectAsync(int id, UpdateProjectDto? dto);
    Task<ResponseResult> DeleteProjectAsync(int id);
}