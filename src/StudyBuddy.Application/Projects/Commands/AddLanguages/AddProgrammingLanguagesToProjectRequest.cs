using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddLanguages;

public record AddProgrammingLanguagesToProjectRequest(
    Guid ProjectId,
    IEnumerable<ProgrammingLanguageDto> Languages)
    : ICommand;
    