using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Projects.Queries.GetProgrammingLanguages;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Project;

public class GetProjectProgrammingLanguagesRequestHandler : IQueryHandler<GetProjectProgrammingLanguagesRequest, ICollection<ProgrammingLanguageDto>>
{
    public Task<ICollection<ProgrammingLanguageDto>> Handle(GetProjectProgrammingLanguagesRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}