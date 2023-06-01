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
        var leader = MemberDto(team.Leader);
        var members = team.Members.Select(MemberDto);
        var projects = team.Projects.Select(ProjectDto);

        return new TeamDto(
            team.Id.Value,
            team.Name.ToString(),
            leader,
            members,
            projects);
    }

    public static MemberDto MemberDto(Member member)
    {
        return new MemberDto(
            member.Id.Value,
            member.User.Username.ToString(),
            member.User.Email.ToString(),
            member.User.Firstname.ToString(),
            member.User.Lastname.ToString(),
            member.User.RegisterNumber.ToString(),
            member.Role.ToString(),
            member.JoinDate);
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
            project.EstimatedTimeToFinish,
            project.Deadline,
            project.ProjectState.ToString());
    }

    public static ProjectRequirementDto ProjectRequirementDto(ProjectRequirement projectRequirement)
    {
        return new ProjectRequirementDto(projectRequirement.Name, projectRequirement.Description);
    }

    public static ProjectTechnologyDto ProjectTechnologyDto(ProjectTechnology projectTechnology)
    {
        return new ProjectTechnologyDto(projectTechnology.Name, projectTechnology.Description, projectTechnology.Version);
    }

    public static ProgrammingLanguageDto ProjectLanguageDto(ProgrammingLanguage programmingLanguage)
    {
        return new ProgrammingLanguageDto(programmingLanguage.Name, programmingLanguage.Version);
    }
}