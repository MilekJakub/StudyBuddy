using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectRequirement : IValueObject
{
	private ProjectRequirement()
	{
		// For Entity Framework	
	}
	
	public ProjectRequirement(string requirement, string description)
	{
		// TODO: checks
		Name = requirement;
		Description = description;
	}

	public string Name { get; }
	public string Description { get; }
	
	public override string ToString()
	{
		return Name;
	}
}