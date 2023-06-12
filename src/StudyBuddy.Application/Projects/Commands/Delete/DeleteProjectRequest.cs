﻿using System.Security.Claims;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.Delete;

public record DeleteProjectRequest(Guid ProjectId) : ICommand
{
    private IEnumerable<Claim> _claims;
    public void SetClaims(IEnumerable<Claim> claims) => _claims = claims;
    public IEnumerable<Claim> GetClaims() => _claims;
}