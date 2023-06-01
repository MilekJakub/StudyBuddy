using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record Lastname : IValueObject
{
	private Lastname()
	{
		// For Entity Framework
	}
	
	public Lastname(string lastname)
	{
		// TODO: checks
		Value = lastname;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}