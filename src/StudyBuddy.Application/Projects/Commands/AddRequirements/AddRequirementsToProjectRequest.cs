using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Commands.AddRequirements;

public record AddRequirementsToProjectRequest(
    Guid ProjectId,
    IEnumerable<ProjectRequirementDto> Requirements)
    : ICommand;