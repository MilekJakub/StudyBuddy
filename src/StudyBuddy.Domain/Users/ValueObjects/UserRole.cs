using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record UserRole : IValueObject
{
	public static IEnumerable<string> AvailableRoles { get; } = new[] {"admin", "teacher", "student"};

	private UserRole()
	{
		// For Entity Framework
	}
	
	public UserRole(string role)
	{
		// TODO: checks
		Value = role;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}