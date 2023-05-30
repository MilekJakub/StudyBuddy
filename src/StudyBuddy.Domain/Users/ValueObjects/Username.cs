using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Users.ValueObjects;

public class Username : ValueObject
{
	public Username(string username)
	{
		// TODO: checks
		Value = username;
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