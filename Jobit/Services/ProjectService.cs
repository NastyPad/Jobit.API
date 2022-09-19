using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class ProjectService: IProjectService
{
    //Remember than in service, we use repo.
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork; 
    }

    public async Task<IEnumerable<Project>> ListProjectsAsync()
    {
        return await _projectRepository.ListProjectsAsync();
    }

    public async Task<Project> FindProjectByProjectIdAsync(long projectId)
    {
        return await _projectRepository.FindProjectByProjectIdAsync(projectId);
    }

    public async Task<ProjectResponse> AddProjectAsync(Project newProject)
    {
        await _projectRepository.AddProjectAsync(newProject);
        await _unitOfWork.CompleteAsync();
        return new ProjectResponse("Successfully saved!");
    }

    public async Task<ProjectResponse> UpdateProjectAsync(long projectId, Project updatedProject)
    {
        var existingProject = await _projectRepository.FindProjectByProjectIdAsync(projectId);
        if (existingProject == null)
            return new ProjectResponse("Not found");
        existingProject.Description = updatedProject.Description;
        existingProject.CodeSource = updatedProject.CodeSource;
        existingProject.ProjectName = updatedProject.ProjectName;
        existingProject.ProjectUrl = updatedProject.ProjectUrl;
        existingProject.User = updatedProject.User;
        _projectRepository.UpdateProject(existingProject);
        await _unitOfWork.CompleteAsync();
        return new ProjectResponse("Successfully updated!");
    }

    public async Task<ProjectResponse> DeleteProjectAsync(long projectId)
    {
        var existingProject = await _projectRepository.FindProjectByProjectIdAsync(projectId);
        if (existingProject == null)
            return new ProjectResponse("Not found");
        _projectRepository.DeleteProject(existingProject);
        await _unitOfWork.CompleteAsync();
        return new ProjectResponse("Element deleted successfully");
    }
} 



