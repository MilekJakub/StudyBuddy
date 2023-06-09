using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.RemoveLanguages;

public record RemoveProgrammingLanguagesFromProjectRequest(
    Guid ProjectId,
    IEnumerable<string> Languages)
    : ICommand;