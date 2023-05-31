using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.RemoveProgrammingLanguages;

public record RemoveProgrammingLanguagesFromProjectRequest(
    Guid ProjectId,
    IEnumerator<string> Languages) : ICommand;