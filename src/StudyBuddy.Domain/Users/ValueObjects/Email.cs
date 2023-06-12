using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record Email : IValueObject
{
	private Email()
	{
		// For Entity Framework
	}
	
	public Email(string email)
	{
		// TODO: checks
		Value = email;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}