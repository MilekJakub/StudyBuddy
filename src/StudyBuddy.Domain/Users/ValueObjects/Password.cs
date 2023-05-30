using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public class Password : ValueObject
{
	public Password(string password)
	{
		// TODO: checks
		Value = password;
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