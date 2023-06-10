using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Queries.GetLanguages;

public class GetProjectProgrammingLanguagesRequestHandler
    : IQueryHandler<GetProjectProgrammingLanguagesRequest, IEnumerable<ProgrammingLanguageDto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectProgrammingLanguagesRequestHandler(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProgrammingLanguageDto>> Handle(
        GetProjectProgrammingLanguagesRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(new ProjectId(request.ProjectId), cancellationToken);
        
        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }

        return project.ProgrammingLanguages.Select(Mapper.ProjectLanguageDto);
    }
}