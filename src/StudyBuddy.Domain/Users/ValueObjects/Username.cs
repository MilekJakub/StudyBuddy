using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record Username : IValueObject
{
	private Username()
	{
		// For Entity Framework
	}
	
	public Username(string username)
	{
		// TODO: checks
		Value = username;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}