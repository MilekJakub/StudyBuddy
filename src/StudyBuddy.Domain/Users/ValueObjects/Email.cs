using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record Email : IValueObject
{
	public Email()
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