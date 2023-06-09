using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Queries.GetById;

public class GetProjectByIdRequestHandler
    : IQueryHandler<GetProjectByIdRequest, ProjectDto>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectByIdRequestHandler(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<ProjectDto> Handle(
        GetProjectByIdRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(request.Id, cancellationToken);

        if (project is null)
        {
            throw new ProjectNotFoundException(request.Id.ToString());
        }

        return Mapper.ProjectDto(project);
    }
}