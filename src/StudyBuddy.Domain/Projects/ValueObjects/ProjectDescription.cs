using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectDescription : IValueObject
{
	private ProjectDescription()
	{
		// For Entity Framework
	}
	
	public ProjectDescription(string projectDescription)
	{
		// TODO: checks
		Value = projectDescription;
	}

	public string Value { get; set; }

	public override string ToString()
	{
		return Value;
	}
}