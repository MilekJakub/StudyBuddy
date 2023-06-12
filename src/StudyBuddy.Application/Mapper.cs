using StudyBuddy.Application.Projects.DTOs;
using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Application.Users.DTOs;
using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Users;

namespace StudyBuddy.Application;

public static class Mapper
{
    public static UserDto UserDto(User user)
    {
        return new UserDto(
            user.Id.Value,
            user.Username.ToString(),
            user.Email.ToString(),
            user.Firstname.ToString(),
            user.Lastname.ToString(),
            user.RegisterNumber.ToString());
    }

    public static TeamDto TeamDto(Team team)
    {
        var members = team.Memberships.Select(MemberDto);
        var projects = team.Projects.Select(ProjectDto);

        return new TeamDto(
            team.Id.Value,
            team.Name.ToString(),
            members,
            projects);
    }

    public static MemberDto MemberDto(Membership membership)
    {
        return new MemberDto(
            membership.Id.Value,
            membership.User.Username.ToString(),
            membership.User.Email.ToString(),
            membership.User.Firstname.ToString(),
            membership.User.Lastname.ToString(),
            membership.User.RegisterNumber.ToString(),
            membership.Team.Name.ToString(),
            membership.Role.ToString(),
            membership.JoinDate);
    }

    public static ProjectDto ProjectDto(Project project)
    {
        var requirements = project.Requirements.Select(ProjectRequirementDto);
        var technologies = project.Technologies.Select(ProjectTechnologyDto);
        var languages = project.ProgrammingLanguages.Select(ProjectLanguageDto);

        return new ProjectDto(
            project.Topic.ToString(),
            project.Description.ToString(),
            requirements,
            technologies,
            languages,
            project.ProjectDifficultyId.ToString(),
            project.EstimatedTimeToFinish.Value,
            project.Deadline.Value,
            project.ProjectStateId.ToString());
    }

    public static ProjectRequirementDto ProjectRequirementDto(ProjectRequirement projectRequirement)
        => new(projectRequirement.Requirement, projectRequirement.Description);

    public static ProjectTechnologyDto ProjectTechnologyDto(Technology technology)
        => new(technology.Name, technology.Description, technology.Version);

    public static ProgrammingLanguageDto ProjectLanguageDto(ProgrammingLanguage programmingLanguage)
        => new(programmingLanguage.Name, programmingLanguage.Version);
}