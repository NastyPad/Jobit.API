using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Domain.Repositories;

namespace Jobit.API.Jobit.Services;

public class ProjectService: IProjectService
{
    //Remember than in service, we use repo.
    private readonly IProjectRepository _projectRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ProjectService(IProjectRepository projectRepository, IUnitOfWork unitOfWork, IApplicantRepository applicantRepository)
    {
        
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
        _applicantRepository = applicantRepository;
    }

    public async Task<IEnumerable<Project>> ListProjectsAsync()
    {
        var projects = await _projectRepository.ListProjectsAsync();
        projects.ToList().ForEach(async project =>
            {
                project.Applicant = await _applicantRepository.FindApplicantByApplicantIdAsync(project.ApplicantId);
            });
        return projects.AsEnumerable();
    }

    public async Task<ProjectResponse> FindProjectByProjectIdAsync(long projectId)
    {
        
        var exisitingProject = await _projectRepository.FindProjectByProjectIdAsync(projectId);
        if (exisitingProject == null)
            return new ProjectResponse("Project does not exist.");
        exisitingProject.Applicant = await _applicantRepository.FindApplicantByApplicantIdAsync(exisitingProject.ApplicantId);
        return new ProjectResponse(exisitingProject);
    }

    public async Task<ProjectResponse> AddProjectAsync(Project newProject)
    {
        try
        {
            await _projectRepository.AddProjectAsync(newProject);
            await _unitOfWork.CompleteAsync();
            return new ProjectResponse(newProject);
        }
        catch (Exception exception)
        {
            return new ProjectResponse($"An error has occurred: {exception.Message}");
        }
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
        try
        {
            _projectRepository.UpdateProject(existingProject);
            await _unitOfWork.CompleteAsync();
            return new ProjectResponse(existingProject);
        }
        catch (Exception exception)
        {
            return new ProjectResponse($"An error has occurred: {exception.Message}");
        }
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




