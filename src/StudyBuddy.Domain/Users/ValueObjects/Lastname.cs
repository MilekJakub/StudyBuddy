using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

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