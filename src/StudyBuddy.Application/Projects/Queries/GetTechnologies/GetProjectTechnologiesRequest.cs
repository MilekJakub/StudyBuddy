using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetTechnologies;

public record GetProjectTechnologiesRequest(Guid ProjectId)
    : IQuery<IEnumerable<ProjectTechnologyDto>>;