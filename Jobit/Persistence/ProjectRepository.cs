
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Security.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class ProjectRepository : BaseRepository, IProjectRepository
{
    private IUserRepository _userRepository;
    public ProjectRepository(AppDatabaseContext databaseContext, IUserRepository userRepository) : base(databaseContext)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Project>> ListProjectsAsync()
    {
        return await databaseContext.Projects.ToListAsync(); //Como?
    }

    public async Task AddProjectAsync(Project newProject)
    {
        //var user = await _userRepository.FindByUserIdAsync(newProject.UserId);
        //newProject.User = user;
        await databaseContext.Projects.AddAsync(newProject);
    }

    public void UpdateProject(Project updatedProject)
    {
        databaseContext.Projects.Update(updatedProject);
    }

    public void DeleteProject(Project toDeleteProject)
    {
        databaseContext.Projects.Remove(toDeleteProject);
    }

    public async Task<Project> FindProjectByProjectIdAsync(long projectId)
    {
        return await databaseContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
    }
}