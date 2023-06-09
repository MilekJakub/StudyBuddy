using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.ValueObjects;

/// <summary>
/// Register Number is an unique number to identify every student.
/// </summary>
public sealed record RegisterNumber : IValueObject
{
	private RegisterNumber()
	{
		// For Entity Framework
	}
	
	public RegisterNumber(string registerNumber)
	{
		// TODO: checks
		Value = registerNumber;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}