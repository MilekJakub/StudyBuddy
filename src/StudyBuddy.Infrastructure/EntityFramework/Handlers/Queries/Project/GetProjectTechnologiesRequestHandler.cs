using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Projects.Queries.GetTechnologies;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Project;

public class GetProjectTechnologiesRequestHandler : IQueryHandler<GetProjectTechnologiesRequest, ICollection<ProjectTechnologyDto>>
{
    public Task<ICollection<ProjectTechnologyDto>> Handle(GetProjectTechnologiesRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}