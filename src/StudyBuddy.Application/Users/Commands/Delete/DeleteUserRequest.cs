using System.Security.Claims;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Delete;

public record DeleteUserRequest(Guid Id) : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}