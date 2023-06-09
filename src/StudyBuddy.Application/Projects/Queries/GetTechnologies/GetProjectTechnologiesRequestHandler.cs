using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Queries.GetTechnologies;

public class GetProjectTechnologiesRequestHandler
    : IQueryHandler<GetProjectTechnologiesRequest, IEnumerable<ProjectTechnologyDto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectTechnologiesRequestHandler(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectTechnologyDto>> Handle(
        GetProjectTechnologiesRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(request.ProjectId, cancellationToken);
        
        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }

        return project.Technologies.Select(Mapper.ProjectTechnologyDto);
    }
}