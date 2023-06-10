using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Projects.ValueObjects;

namespace StudyBuddy.Domain.Repositories;

public interface IProjectRepository
{
    Task<Project?> GetByIdAsync(ProjectId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Project>> GetAll(CancellationToken cancellationToken = default);
    Task<ProjectDifficulty> GetDifficultyByIdAsync(byte id, CancellationToken cancellationToken = default);
    Task<ProjectState> GetStateByIdAsync(byte id, CancellationToken cancellationToken = default);
    Task AddAsync(Project project, CancellationToken cancellationToken = default);
    Task RemoveAsync(Project project, CancellationToken cancellationToken = default);
}