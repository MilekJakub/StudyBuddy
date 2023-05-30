using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public class MemberRole : ValueObject
{
	public MemberRole(string role)
	{
		// TODO: checks
		Value = role;
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