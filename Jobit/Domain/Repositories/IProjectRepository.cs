using Jobit.API.Jobit.Domain.Models;

namespace Jobit.API.Jobit.Domain.Repositories;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> ListProjectsAsync();
    Task AddProjectAsync(Project newProject);
    void UpdateProject(Project updatedProject);
    void DeleteProject(Project toDeleteProject);
    
    Task<Project?> FindProjectByProjectIdAsync(long projectId);
}