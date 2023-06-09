using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetAll;

public record GetAllProjectsRequest()
    : IQuery<IEnumerable<ProjectDto>>;