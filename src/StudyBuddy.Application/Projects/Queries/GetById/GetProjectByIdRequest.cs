using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Projects.Queries.GetById;

public record GetProjectByIdRequest(Guid Id) : IQuery<ProjectDto>;