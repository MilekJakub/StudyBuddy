using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectRequirement : ValueObject
{
	public ProjectRequirement(string requirement)
	{
		// TODO: checks
		Value = requirement;
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