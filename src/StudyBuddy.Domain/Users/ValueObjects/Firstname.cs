using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record Firstname : IValueObject
{
	private Firstname()
	{
		// For Entity Framework
	}
	
	public Firstname(string firstname)
	{
		// TODO: checks
		Value = firstname;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}