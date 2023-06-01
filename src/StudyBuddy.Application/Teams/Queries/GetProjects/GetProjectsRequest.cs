using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Queries.GetProjects;

public record GetProjectsRequest(Guid TeamId) : IQuery<ICollection<ProjectDto>>;