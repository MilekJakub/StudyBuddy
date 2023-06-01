using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Projects.Queries.GetRequirements;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Project;

public class GetProjectRequirementsRequestHandler : IQueryHandler<GetProjectRequirementsRequest, ICollection<ProjectRequirementDto>>
{
    public Task<ICollection<ProjectRequirementDto>> Handle(GetProjectRequirementsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}