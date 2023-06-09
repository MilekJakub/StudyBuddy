using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record PasswordHash : IValueObject
{
	private PasswordHash()
	{
		// For Entity Framework	
	}
	
	public PasswordHash(string password)
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