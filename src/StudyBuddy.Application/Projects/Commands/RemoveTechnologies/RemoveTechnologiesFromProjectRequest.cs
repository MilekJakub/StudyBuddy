using System.Security.Claims;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.RemoveTechnologies;

public record RemoveTechnologiesFromProjectRequest(
        Guid ProjectId,
        IEnumerable<string> Technologies)
    : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}