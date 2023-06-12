using System.Security.Claims;
using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddRequirements;

public record AddRequirementsToProjectRequest(
        Guid ProjectId,
        IEnumerable<ProjectRequirementDto> Requirements)
    : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}