using System.Security.Claims;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Responses;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

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
        var claims = request.GetClaims();
        var userId = claims.FirstOrDefault(x => x.Type == "userId")?.Value;
        var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var isAdminOrTeacher = role is "admin" or "teacher";

        if (userId is null && !isAdminOrTeacher)
        {
            throw new UnauthorizedException();
        }

        var team = await _teamRepository
            .GetByIdAsync(new TeamId(request.TeamId), cancellationToken);

        if (team is null)
        {
            throw new TeamNotFoundException(request.TeamId.ToString());
        }
        
        var userMembership = team.Memberships.FirstOrDefault(x => x.UserId.Value == Guid.Parse(userId));

        if (userMembership is null && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamMemberException");
        }

        if (userMembership?.UserId != team.GetLeader().UserId && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamLeaderException");
        }

        var membership = team.Memberships.FirstOrDefault(m => m.Id.Value == request.MemberId);

        if (membership is null)
        {
            throw new MembershipNotFoundException(request.MemberId.ToString());
        }
        
        team.KickMember(membership.Id);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}