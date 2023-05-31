using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.ChangeDifficulty;

public record ChangeProjectDifficultyRequest(Guid ProjectId, ProjectDifficulty Difficulty) : ICommand;