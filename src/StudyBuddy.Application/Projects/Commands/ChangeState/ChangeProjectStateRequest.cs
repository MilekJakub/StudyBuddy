using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.ChangeState;

public record ChangeProjectStateRequest(Guid ProjectId, ProjectState State) : ICommand;