using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectTopic : IValueObject
{
	private ProjectTopic()
	{
		// For Entity Framework	
	}
	
	public ProjectTopic(string topic)
	{
		// TODO: checks
		Value = topic;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}