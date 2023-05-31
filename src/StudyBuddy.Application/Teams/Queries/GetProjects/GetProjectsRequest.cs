using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Queries;

public record GetProjectsRequest(Guid TeamId) : IQuery<IEnumerable<ProjectDto>>;