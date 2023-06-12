using System.Security.Claims;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.ChangeLeader;

public record ChangeTeamLeaderRequest
    (Guid TeamId, Guid NewLeaderMembershipId, string NewRoleForPreviousLeader) : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}