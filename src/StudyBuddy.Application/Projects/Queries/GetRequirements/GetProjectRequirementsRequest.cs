using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetRequirements;

public record GetProjectRequirementsRequest(Guid ProjectId)
    : IQuery<IEnumerable<ProjectRequirementDto>>;