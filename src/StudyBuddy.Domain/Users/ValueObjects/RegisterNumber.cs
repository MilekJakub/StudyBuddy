using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

/// <summary>
/// Register Number is an unique number to identify every student.
/// </summary>
public class RegisterNumber : ValueObject
{
	public RegisterNumber(string registerNumber)
	{
		// TODO: checks
		Value = registerNumber;
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