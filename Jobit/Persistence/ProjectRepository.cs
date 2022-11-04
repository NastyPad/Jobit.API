
using Jobit.API.Jobit.Domain.Models;
using Jobit.API.Jobit.Domain.Repositories;
using Jobit.API.Shared.Persistence.Context;
using Jobit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Jobit.API.Jobit.Persistence;

public class ProjectRepository : BaseRepository, IProjectRepository
{
    public ProjectRepository(AppDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IEnumerable<Project>> ListProjectsAsync()
    {
        return await _databaseContext.Projects.ToListAsync(); //Como?
    }

    public async Task AddProjectAsync(Project newProject)
    {
        await _databaseContext.Projects.AddAsync(newProject);
    }

    public void UpdateProject(Project updatedProject)
    {
        _databaseContext.Projects.Update(updatedProject);
    }

    public void DeleteProject(Project toDeleteProject)
    {
        _databaseContext.Projects.Remove(toDeleteProject);
    }

    public async Task<Project> FindProjectByProjectIdAsync(long projectId)
    {
        return await _databaseContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);
    }
}