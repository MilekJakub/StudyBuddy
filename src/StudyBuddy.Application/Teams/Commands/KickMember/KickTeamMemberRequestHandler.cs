using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.KickMember;

public class KickTeamMemberRequestHandler
    : ICommandHandler<KickTeamMemberRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public KickTeamMemberRequestHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        KickTeamMemberRequest request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository
            .GetByIdAsync(new TeamId(request.TeamId), cancellationToken);

        var membership = await _teamRepository
            .GetMembershipByIdAsync(new MembershipId(request.MemberId));
        
        team.KickMember(membership.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}