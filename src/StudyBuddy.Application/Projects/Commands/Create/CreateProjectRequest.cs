using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.Create;

public record CreateProjectRequest(
    Guid Id,
    string Topic,
    string Description,
    ProjectDifficulty Difficulty,
    DateTime EstimatedTimeToFinish,
    DateTime Deadline) : ICommand;
