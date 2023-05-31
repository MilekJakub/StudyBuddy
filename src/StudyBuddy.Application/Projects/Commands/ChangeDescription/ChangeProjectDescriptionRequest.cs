using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.ChangeDescription;

public record ChangeProjectDescriptionRequest(Guid ProjectId, string Description) : ICommand;