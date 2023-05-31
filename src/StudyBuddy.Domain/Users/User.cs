using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Users.Events;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users;

public class User : Entity<UserId>
{
    private readonly List<Membership> _memberships = new();

    public User(
		UserId id,
		Username username,
		Email email,
		PasswordHash hash,
        UserRole role,
		Firstname firstname,
		Lastname lastname,
        RegisterNumber registerNumber,
		DateTime createdAt)
    {
        Id = id;
        Email = email;
        Username = username;
        PasswordHash = hash;
        Role = role;
        Firstname = firstname;
		Lastname = lastname;
        RegisterNumber = registerNumber;
        CreatedAt = createdAt;
        
        AddEvent(new UserRegisteredEvent(this));
    }

	public Username Username { get; private set; }
    public Email Email { get; private set; }
    public PasswordHash PasswordHash { get; private set; }
    public UserRole Role { get; private set; }
    public Firstname Firstname { get; private set; }
	public Lastname Lastname { get; private set; }
    public RegisterNumber RegisterNumber { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public IReadOnlyCollection<Membership> Memberships => _memberships;
}