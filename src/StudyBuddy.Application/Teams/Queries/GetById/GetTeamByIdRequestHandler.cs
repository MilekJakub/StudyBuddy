using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Queries.GetById;

public class GetTeamByIdRequestHandler
    : IQueryHandler<GetTeamByIdRequest, TeamDto>
{
    private readonly ITeamRepository _teamRepository;

    public GetTeamByIdRequestHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<TeamDto> Handle(
        GetTeamByIdRequest request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository.GetByIdAsync(request.Id, cancellationToken);

        if (team is null)
        {
            throw new TeamNotFoundException(request.Id.ToString());
        }

        return Mapper.TeamDto(team);
    }
}