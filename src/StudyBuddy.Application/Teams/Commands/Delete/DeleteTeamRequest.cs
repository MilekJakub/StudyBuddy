using System.Security.Claims;
using System.Text;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.Delete;

public record DeleteTeamRequest(Guid Id) : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}