using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.Enums.ProjectDifficulty;
using StudyBuddy.Domain.Projects.Enums.ProjectState;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Tests.UnitTests.Domain;

public static class TestEntitiesGenerator
{
    public static Team GetTestTeam()
    {
        return new Team(
        id: new TeamId(Guid.Parse("F395BD3A-B638-479D-BE26-4B612749EA98")),
        name: new TeamName("testName"),
        description: new TeamDescription("testDescription"),
        teamFounder: GetTestUser());
    }
    
    public static User GetTestUser()
    {
        return
        new User(
        id: new UserId(Guid.Parse("d1f51d19-ad78-40c6-83d7-3c7f38f37c79")),
        username: new Username("kamilz"),
        email: new Email("kamil.zydlo@microsoft.wsei.edu.pl"),
        hash: new PasswordHash("aqaaaaiaayagaaaaedslygmcpd8wrsrqswbwqh5f2cexh70i1i4/vbkn2cucfh88iclyygfdvo+gcnh1hw=="),
        role: new UserRole("user"),
        firstname: new Firstname("kamil"),
        lastname: new Lastname("żydło"),
        registerNumber: new RegisterNumber("12312"),
        createdAt: DateTime.UtcNow);
    }

    public static Project GetTestProject()
    {
        return
        new Project(
            id: new ProjectId(Guid.Parse("962E210E-7477-4377-95E4-216781F5A70F")),
            topic: new ProjectTopic("Study Buddy"),
            description: new ProjectDescription("Managing studnets' projects, and more!"),
            difficulty: new ProjectDifficulty("test"),
            estimatedTimeToFinish: new EstimatedTime(5, 0, 0, 0),
            deadline: new Deadline(new DateTime(2023, 06, 13, 17, 0, 0, 0)),
            state: new ProjectState("test"),
            creator: GetTestUser());
    }
}