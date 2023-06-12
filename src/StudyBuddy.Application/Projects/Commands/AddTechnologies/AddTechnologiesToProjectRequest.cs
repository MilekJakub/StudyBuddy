using System.Security.Claims;
using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddTechnologies;

public record AddTechnologiesToProjectRequest(
        Guid ProjectId,
        IEnumerable<ProjectTechnologyDto> Technologies)
    : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}