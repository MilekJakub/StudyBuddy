using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Queries.GetRequirements;

public class GetProjectRequirementsRequestHandler
    : IQueryHandler<GetProjectRequirementsRequest, IEnumerable<ProjectRequirementDto>>
{
    private readonly IProjectRepository _projectRepository;

    public GetProjectRequirementsRequestHandler(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<ProjectRequirementDto>> Handle(
        GetProjectRequirementsRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(new ProjectId(request.ProjectId), cancellationToken);
        
        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }
        
        return project.Requirements.Select(Mapper.ProjectRequirementDto);
    }
}