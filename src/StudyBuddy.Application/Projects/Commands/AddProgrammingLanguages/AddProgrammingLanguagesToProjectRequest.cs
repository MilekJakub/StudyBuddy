using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddProgrammingLanguages;

public record AddProgrammingLanguagesToProjectRequest(Guid ProjectId, IEnumerable<string> Languages) : ICommand;