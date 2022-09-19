using AutoMapper;
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Services;
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
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ProjectController(IProjectService projectService, IUserRepository userRepository,IMapper mapper)
    {
        _projectService = projectService;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProjectResource>> GetAllProjectsAsync()
    {
        
        var projects = await _projectService.ListProjectsAsync();
        var enumerable = projects.ToList();
        enumerable.ToList().ForEach(project =>
            project.User = _userRepository.FindByUserIdAsync(project.UserId).Result); 
        var resources = _mapper.Map<IEnumerable<Project>, IEnumerable<ProjectResource>>(enumerable);
        return resources;
    }
    
    [AllowAnonymous]
    [HttpPost]
    [SwaggerResponse(200, "The operation was successful", typeof(SaveProjectResource))]
    [SwaggerResponse(500, "The project data is not valid")]
    public async Task<IActionResult> PostProjectAsync([FromBody, SwaggerRequestBody("Project")] SaveProjectResource newProject)
    {
        var project = _mapper.Map<SaveProjectResource, Project>(newProject);
        var user = await _userRepository.FindByUserIdAsync(newProject.UserId);
        project.User = user;
        await _projectService.AddProjectAsync(project);
        var newProjectResponse = _mapper.Map<Project, ProjectResource>(await _projectService.FindProjectByProjectIdAsync(project.ProjectId));
        return Ok(newProjectResponse);
    }
}