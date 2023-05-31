using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.Delete;

public record DeleteProjectRequest(Guid ProjectId) : ICommand;