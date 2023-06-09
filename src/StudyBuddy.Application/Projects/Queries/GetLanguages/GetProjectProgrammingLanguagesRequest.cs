using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetLanguages;

public record GetProjectProgrammingLanguagesRequest(Guid ProjectId)
    : IQuery<IEnumerable<ProgrammingLanguageDto>>;