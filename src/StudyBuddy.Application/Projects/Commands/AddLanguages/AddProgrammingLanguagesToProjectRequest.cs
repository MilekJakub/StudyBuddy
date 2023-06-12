using System.Security.Claims;
using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddLanguages;

public record AddProgrammingLanguagesToProjectRequest(
        Guid ProjectId,
        IEnumerable<ProgrammingLanguageDto> Languages)
    : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}
    