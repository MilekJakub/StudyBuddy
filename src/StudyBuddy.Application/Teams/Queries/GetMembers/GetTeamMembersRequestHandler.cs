using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Queries.GetMembers;

public class GetTeamMembersRequestHandler
    : IQueryHandler<GetTeamMembersRequest, IEnumerable<MemberDto>>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamMembersRequestHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<MemberDto>> Handle(
        GetTeamMembersRequest request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository
            .GetByIdAsync(new TeamId(request.TeamId), cancellationToken);

        if (team is null)
        {
            throw new TeamNotFoundException(request.TeamId.ToString());
        }

        
        return team.Memberships.Select(Mapper.MemberDto);
    }
}