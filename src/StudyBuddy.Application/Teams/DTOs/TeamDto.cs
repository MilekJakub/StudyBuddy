using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Users.DTOs;

namespace StudyBuddy.Application.Teams.DTOs;

public record TeamDto(
    Guid Id,
    string Name,
    IEnumerable<MemberDto> Members,
    IEnumerable<ProjectDto> CompletedProjects);