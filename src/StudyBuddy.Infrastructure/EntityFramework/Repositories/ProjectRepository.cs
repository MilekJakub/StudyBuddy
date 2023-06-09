using Microsoft.EntityFrameworkCore;
using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Infrastructure.EntityFramework.Contexts;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Infrastructure.EntityFramework.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DbSet<Project> _projects;
    private DbSet<ProjectRequirement> _projectRequirements;
    private DbSet<ProjectTechnology> _projectTechnologies;
    private DbSet<ProgrammingLanguage> _programmingLanguages;
    private DbSet<ProjectDifficulty> _projectDifficulties;
    private DbSet<ProjectState> _projectStates;

    public ProjectRepository(ApplicationDbContext context)
    {
        _projects = context.Projects;
        _projectRequirements = context.ProjectRequirements;
        _projectTechnologies = context.ProjectTechnologies;
        _programmingLanguages = context.ProgrammingLanguages;
        _projectDifficulties = context.ProjectDifficulties;
        _projectStates = context.ProjectStates;
    }
    
    public async Task<Project> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var project = await _projects
            .Include(p => p.Requirements)
            .Include(p => p.Technologies)
            .Include(p => p.ProgrammingLanguages)
            .Include(p => p.Team)
            .Include(p => p.ProjectDifficulty)
            .Include(p => p.ProjectState)
            .SingleOrDefaultAsync(cancellationToken);
        
        if (project is null)
        {
            throw new ProjectNotFoundException(id.ToString());
        }

        return project;
    }

    public async Task<IEnumerable<Project>> GetAll(CancellationToken cancellationToken = default)
    {
        return
             await _projects
            .Include(p => p.Requirements)
            .Include(p => p.Technologies)
            .Include(p => p.ProgrammingLanguages)
            .Include(p => p.Team)
            .Include(p => p.ProjectDifficulty)
            .Include(p => p.ProjectState)
            .ToListAsync(cancellationToken);
    }

    public async Task<ProjectDifficulty> GetDifficultyByIdAsync(
        byte id,
        CancellationToken cancellationToken = default)
    {
        var difficulty = await _projectDifficulties
            .SingleOrDefaultAsync(pd => (byte) pd.Id == id, cancellationToken);

        if (difficulty is null)
        {
            throw new DifficultyNotFoundException(id.ToString());
        }

        return difficulty;
    }

    public async Task<ProjectState> GetStateByIdAsync(
        byte id,
        CancellationToken cancellationToken = default)
    {
        var state = await _projectStates
            .SingleOrDefaultAsync(ps => (byte)ps.Id == id, cancellationToken);

        if (state is null)
        {
            throw new StateNotFoundException(id.ToString());
        }

        return state;
    }

    public async Task AddAsync(
        Project project,
        CancellationToken cancellationToken = default)
    {
        await _projects.AddAsync(project, cancellationToken);
    }

    public Task RemoveAsync(
        Project project,
        CancellationToken cancellationToken = default)
    {
        _projects.Remove(project);
        return Task.CompletedTask;
    }
}