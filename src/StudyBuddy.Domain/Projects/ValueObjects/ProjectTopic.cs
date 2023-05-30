using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectTopic : ValueObject
{
	public ProjectTopic(string topic)
	{
		// TODO: checks
		Value = topic;
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