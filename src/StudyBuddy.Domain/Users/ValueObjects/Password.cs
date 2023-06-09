using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record Password : IValueObject
{
	private Password()
	{
		// For Entity Framework
	}
	
	public Password(string password)
	{
		// TODO: checks
		Value = password;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}