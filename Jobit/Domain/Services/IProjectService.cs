using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services.Communication;

namespace Jobit.API.Jobit.Domain.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> ListProjectsAsync();
    Task<ProjectResponse> FindProjectByProjectIdAsync(long projectId);
    Task<ProjectResponse> AddProjectAsync(Project newProject);
    Task<ProjectResponse> UpdateProjectAsync(long projectId, Project updatedProject);
    Task<ProjectResponse> DeleteProjectAsync(long projectId);
}