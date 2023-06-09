using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectTopic : IValueObject
{
	public ProjectTopic(string topic)
	{
		// TODO: checks
		// null or empty
		// too long

		Value = topic;
	}

	public string Value { get; init; }

	public override string ToString() => Value;
	
	private ProjectTopic()
	{
		// For Entity Framework	
	}
}