using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.ChangeDeadline;

public record ChangeProjectDeadlineRequest(Guid ProjectId, DateTime Deadline) : ICommand;