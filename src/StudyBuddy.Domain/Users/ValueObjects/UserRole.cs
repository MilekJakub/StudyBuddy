using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public class UserRole : ValueObject
{
	public static IEnumerable<string> AvailableRoles { get; } = new[] {"teacher", "student"};

	public UserRole(string role)
	{
		// TODO: checks
		Value = role;
	}

	public string Value { get; }

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}

	public override string ToString()
	{
		return Value;
	}
}