using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Queries.GetAll;

public class GetAllTeamsRequestHandler
    : IQueryHandler<GetAllTeamsRequest, IEnumerable<TeamDto>>
{
    private readonly ITeamRepository _teamRepository;

    public GetAllTeamsRequestHandler(ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<IEnumerable<TeamDto>> Handle(
    GetAllTeamsRequest request,
    CancellationToken cancellationToken)
    {
        var teams = await _teamRepository.GetAll(cancellationToken);
        var list = teams.ToList();

        if (!list.Any())
        {
            throw new Exception("No team found in the database.");
        }

        return list.Select(Mapper.TeamDto);
    }
}