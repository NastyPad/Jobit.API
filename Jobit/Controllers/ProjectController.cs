using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services;
using Jobit.API.Jobit.Domain.Services.Communication;
using Jobit.API.Jobit.Resources;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Security.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Jobit.API.Jobit.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces("application/json")]
[SwaggerTag("Create, read, update and delete Projects")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IMapper _mapper;

    public ProjectController(IProjectService projectService, IMapper mapper)
    {
        _projectService = projectService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectResource>> GetAllProjectsAsync()
    {
        
        var projects = await _projectService.ListProjectsAsync();
        var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(projects);
        return resources;
    }
    
    [AllowAnonymous]
    [HttpPost]
    [SwaggerResponse(200, "The operation was successful", typeof(SaveProjectResource))]
    [SwaggerResponse(500, "The project data is not valid")]
    public async Task<IActionResult> PostProjectAsync([FromBody, SwaggerRequestBody("Project")] SaveProjectResource newProject)
    {
        var project = _mapper.Map<SaveProjectResource, Project>(newProject);
        await _projectService.AddProjectAsync(project);
        var newProjectResponse = _mapper.Map<Project, ProjectResource>(await _projectService.FindProjectByProjectIdAsync(project.ProjectId));
        return Ok(new ProjectResponse("Successfully added"));
    }


    [HttpPut("{projectId}")]
    public async Task<IActionResult> PutProjectAsync(long projectId, [FromBody, SwaggerRequestBody("Updated Project")] UpdateProjectResource updatedProjectResource)
    {
        var updateProjectMapped = _mapper.Map<UpdateProjectResource, Project>(updatedProjectResource);
        return Ok(await _projectService.UpdateProjectAsync(projectId, updateProjectMapped));
    }

    [HttpDelete("{projectId}")]
    public async Task<IActionResult> DeleteProjectAsync(long projectId)
    {
        var toDeleteProject = _projectService.FindProjectByProjectIdAsync(projectId);

        var result = await _projectService.DeleteProjectAsync(projectId);
        if (!result.Success)
            return BadRequest(result);
        return Ok(toDeleteProject);
    }
}