using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Tests.UnitTests.Domain;

public class TeamTests
{
    [Fact]
    public void Is_Initialized_Correctly()
    {
        
        var team = new Team(
        id: new TeamId(Guid.Parse("F395BD3A-B638-479D-BE26-4B612749EA98")),
        name: new TeamName("testName"),
        description: new TeamDescription("testDescription"),
        teamFounder: 
        new User(
            id: new UserId(Guid.Parse("d1f51d19-ad78-40c6-83d7-3c7f38f37c79")),
            username: new Username("kamilz"),
            email: new Email("kamil.zydlo@microsoft.wsei.edu.pl"),
            hash: new PasswordHash("aqaaaaiaayagaaaaedslygmcpd8wrsrqswbwqh5f2cexh70i1i4/vbkn2cucfh88iclyygfdvo+gcnh1hw=="),
            role: new UserRole("user"),
            firstname: new Firstname("kamil"),
            lastname: new Lastname("żydło"),
            registerNumber: new RegisterNumber("12312"),
            createdAt: DateTime.UtcNow));
        
        
        Assert.NotNull(team);
        Assert.Equal(new TeamId(Guid.Parse("F395BD3A-B638-479D-BE26-4B612749EA98")), team.Id);
        Assert.Equal(new TeamName("testName"), team.Name);
        Assert.Equal(new TeamDescription("testDescription"), team.Description);
        Assert.Equal(1, team.Memberships.Count);
        Assert.Equal(new UserId(Guid.Parse("d1f51d19-ad78-40c6-83d7-3c7f38f37c79")), team.Memberships.First().UserId);
    }
    

    [Fact]
    public void Can_Add_And_Remove_Project_From_Team()
    {
        var team = TestEntitiesGenerator.GetTestTeam();
        var project = TestEntitiesGenerator.GetTestProject();
        
        team.AddProject(project);
        Assert.Equal(1, team.Projects.Count);
        
        team.RemoveProject(project.Id);
        Assert.Equal(0,  team.Projects.Count);
    }

    [Fact]
    public void Can_Change_Leader()
    {
        var team = TestEntitiesGenerator.GetTestTeam();
        
        var membership = new Membership(
            new MembershipId(Guid.Parse("9E024EAD-F380-41FB-8772-E4E264426BAB")),
            team,
            TestEntitiesGenerator.GetTestUser(),
            new ProjectRole("test"),
            DateTime.UtcNow);

        var previousLeader = team.GetLeader();
        
        team.AddMember(membership);
        team.ChangeLeader(membership.Id, new ProjectRole("newrole"));

        var newLeader = team.GetLeader();
        
        Assert.Equal(new ProjectRole("newrole"), previousLeader.Role);
        Assert.Equal(new ProjectRole("Leader"), newLeader.Role);
    }

    [Fact]
    public void Can_Add_Member()
    {
        var team = TestEntitiesGenerator.GetTestTeam();
        
        var membership = new Membership(
            new MembershipId(Guid.Parse("9E024EAD-F380-41FB-8772-E4E264426BAB")),
            team,
            TestEntitiesGenerator.GetTestUser(),
            new ProjectRole("test"),
            DateTime.UtcNow);
        
        team.AddMember(membership);
        Assert.Equal(2, team.Memberships.Count);
        
        team.KickMember(membership.Id);
        Assert.Equal(1, team.Memberships.Count);
    }

    [Fact]
    public void Can_Kick_Member()
    {
        var team = TestEntitiesGenerator.GetTestTeam();
        
        var membership = new Membership(
            new MembershipId(Guid.Parse("9E024EAD-F380-41FB-8772-E4E264426BAB")),
            team,
            TestEntitiesGenerator.GetTestUser(),
            new ProjectRole("test"),
            DateTime.UtcNow);
        
        team.AddMember(membership);
        
        Assert.Equal(2, team.Memberships.Count);
    }

    [Fact]
    public void Can_Change_Name()
    {
        var team = TestEntitiesGenerator.GetTestTeam();
        
        team.ChangeName(new TeamName("testName"));
        
        Assert. Equal(new TeamName("testName"), team.Name);
    }
}