using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Projects.Queries.GetAll;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Project;

public class GetAllProjectsRequestHandler : IQueryHandler<GetAllProjectsRequest, ICollection<ProjectDto>>
{
    public Task<ICollection<ProjectDto>> Handle(GetAllProjectsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}