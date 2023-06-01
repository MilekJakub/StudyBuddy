using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Application.Teams.Queries.GetById;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Team;

public class GetTeamByIdRequestHandler : IQueryHandler<GetTeamByIdRequest, TeamDto>
{
    public Task<TeamDto> Handle(GetTeamByIdRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}