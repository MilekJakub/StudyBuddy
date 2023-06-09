using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Commands.ChangeLeader;

public class ChangeTeamLeaderRequestHandler
    : ICommandHandler<ChangeTeamLeaderRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ChangeTeamLeaderRequestHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        ChangeTeamLeaderRequest request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository
            .GetByIdAsync(request.TeamId, cancellationToken);
        
        if (team is null)
        {
            throw new TeamNotFoundException(request.TeamId.ToString());
        }
        
        var membership = await _teamRepository
            .GetMembershipByIdAsync(request.NewLeaderMembershipId, cancellationToken);
        
        team.ChangeLeader(membership.Id, new ProjectRole(request.NewRoleForPreviousLeader));
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}