using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectTechnology : IValueObject
{
	private ProjectTechnology()
	{
		// For Entity Framework
	}
	
	public ProjectTechnology(string name, string description, string? version)
	{
		// TODO: checks
		Name = name;
		Description = description;
		Version = version;
	}

	public string Name { get; set; }
	public string Description { get; set; }
	public string? Version { get; }

	public override string ToString()
	{
		return Name;
	}
}