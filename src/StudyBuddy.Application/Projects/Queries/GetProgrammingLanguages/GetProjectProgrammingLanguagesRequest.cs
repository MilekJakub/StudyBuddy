using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetProgrammingLanguages;

public record GetProjectProgrammingLanguagesRequest(Guid ProjectId) : IQuery<ICollection<ProgrammingLanguageDto>>;