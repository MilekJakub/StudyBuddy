using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectDescription : IValueObject
{
	public ProjectDescription(string projectDescription)
	{
		// TODO: checks
		Value = projectDescription;
	}

	public string Value { get; init; }

	public override string ToString() => Value;

	private ProjectDescription()
	{
		// For Entity Framework
	}
}