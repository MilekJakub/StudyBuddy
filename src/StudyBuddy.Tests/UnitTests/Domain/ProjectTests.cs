using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Tests.UnitTests.Domain;

public class ProjectTests
{

    [Fact]
    public void Is_Initialized_Correctly()
    {
        var user = new User(
            id: new UserId(Guid.Parse("d1f51d19-ad78-40c6-83d7-3c7f38f37c79")),
            username: new Username("kamilz"),
            email: new Email("kamil.zydlo@microsoft.wsei.edu.pl"),
            hash: new PasswordHash("aqaaaaiaayagaaaaedslygmcpd8wrsrqswbwqh5f2cexh70i1i4/vbkn2cucfh88iclyygfdvo+gcnh1hw=="),
            role: new UserRole("user"),
            firstname: new Firstname("kamil"),
            lastname: new Lastname("żydło"),
            registerNumber: new RegisterNumber("12312"),
            createdAt: DateTime.UtcNow);

        var team = new Team(
            id: new TeamId(Guid.Parse("F395BD3A-B638-479D-BE26-4B612749EA98")),
            name: new TeamName("testName"),
            description: new TeamDescription("testDescription"),
            teamFounder: user);
        
        var project = new Project(
            id: new ProjectId(Guid.Parse("962E210E-7477-4377-95E4-216781F5A70F")),
            topic: new ProjectTopic("Study Buddy"),
            description: new ProjectDescription("Managing studnets' projects, and more!"),
            difficulty: new ProjectDifficulty("test"),
            estimatedTimeToFinish: new EstimatedTime(5, 0, 0, 0),
            deadline: new Deadline(new DateTime(2023, 06, 13, 17, 0, 0, 0)),
            state: new ProjectState("test"),
            creator: user,
            team: team);

        Assert.NotNull(project.Team);
        Assert.Equal(new TeamId(Guid.Parse("F395BD3A-B638-479D-BE26-4B612749EA98")), project.Team.Id);
        Assert.Equal(new TeamName("testName"), project.Team.Name);
        Assert.Equal(new TeamDescription("testDescription"), project.Team.Description);
        Assert.Equal(1, project.Team.Memberships.Count);
        
        Assert.NotNull(project.Team.Memberships.First());
        Assert.Equal(new UserId(Guid.Parse("d1f51d19-ad78-40c6-83d7-3c7f38f37c79")), project.Team.Memberships.First().User.Id);
        
        Assert.Equal(new ProjectId(Guid.Parse("962E210E-7477-4377-95E4-216781F5A70F")), project.Id);
        Assert.Equal(new ProjectTopic("Study Buddy"), project.Topic);
        Assert.Equal(new ProjectDescription("Managing studnets' projects, and more!"), project.Description);
    }
}