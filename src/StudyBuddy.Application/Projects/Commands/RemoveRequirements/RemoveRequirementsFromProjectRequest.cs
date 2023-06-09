using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.RemoveRequirements;

public record RemoveRequirementsFromProjectRequest(
    Guid ProjectId,
    IEnumerable<string> Requirements)
    : ICommand;