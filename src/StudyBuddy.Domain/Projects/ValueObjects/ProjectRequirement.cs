using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectRequirement : IValueObject
{
	public ProjectRequirement(string requirement, string description)
	{
		// TODO: checks
		Requirement = requirement;
		Description = description;
	}

	public string Requirement { get; init; }
	public string Description { get; init; }
	
	public override string ToString() => Requirement;

	private ProjectRequirement()
	{
		// For Entity Framework	
	}
}