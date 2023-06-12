using System.Security.Claims;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.Update;

public record UpdateUserRequest(
    Guid Id,
    string? Firstname,
    string? Lastname,
    string? RegisterNumber) : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}