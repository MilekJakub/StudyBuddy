using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Tests.UnitTests.Domain;

public class UserTests
{
    [Fact]
    public void Is_Initialized_Correctly()
    {
        var user = 
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

        Assert.NotNull(user);
        Assert.Equal(new UserId(Guid.Parse("d1f51d19-ad78-40c6-83d7-3c7f38f37c79")), user.Id);
        Assert.Equal(new Username("kamilz"), user.Username);
        Assert.Equal(new Email("kamil.zydlo@microsoft.wsei.edu.pl"), user.Email);
        Assert.Equal(new PasswordHash("aqaaaaiaayagaaaaedslygmcpd8wrsrqswbwqh5f2cexh70i1i4/vbkn2cucfh88iclyygfdvo+gcnh1hw=="), user.PasswordHash);
    }

    [Fact]
    public void Can_Change_Email()
    {
        var user = TestEntitiesGenerator.GetTestUser();
        
        user.ChangeEmail(new Email("newemail@email.com"));
        
        Assert.Equal(new Email("newemail@email.com"), user.Email);
    }

    [Fact]
    public void Can_Change_Password()
    {
        var user = TestEntitiesGenerator.GetTestUser();
        user.ChangePassword(new PasswordHash("passwordHashFromExternalLayer"));
        Assert.Equal(new PasswordHash("passwordHashFromExternalLayer"), user.PasswordHash);
    }

    [Fact]
    public void Can_Change_Credentials()
    {
        var user = TestEntitiesGenerator.GetTestUser();
        
        user.ChangeFirstname(new Firstname("testFirstname"));
        user.ChangeLastname(new Lastname("testLastname"));
        user.ChangeRegisterNumber(new RegisterNumber("testRegisterNumber"));
        
        Assert.Equal(new Firstname("testFirstname"), user.Firstname);
        Assert.Equal(new Lastname("testLastname"), user.Lastname);
        Assert.Equal(new RegisterNumber("testRegisterNumber"), user.RegisterNumber);
    }
}