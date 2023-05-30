using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public class TeamName : ValueObject
{
	public TeamName(string name)
	{
		// TODO: checks
		Value = name;
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