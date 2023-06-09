using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.RemoveTechnologies;

public record RemoveTechnologiesFromProjectRequest(
    Guid ProjectId,
    IEnumerable<string> Technologies)
    : ICommand;