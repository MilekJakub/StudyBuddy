using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Projects.Queries.GetById;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Project;

public class GetProjectByIdRequestHandler : IQueryHandler<GetProjectByIdRequest, ProjectDto>
{
    public Task<ProjectDto> Handle(GetProjectByIdRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}