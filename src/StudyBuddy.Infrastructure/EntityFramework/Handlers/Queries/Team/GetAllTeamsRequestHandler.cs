using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Application.Teams.Queries.GetAll;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Queries.Team;

public class GetAllTeamsRequestHandler : IQueryHandler<GetAllTeamsRequest, ICollection<TeamDto>>
{
    public Task<ICollection<TeamDto>> Handle(GetAllTeamsRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}