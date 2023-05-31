using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectTechnology : ValueObject
{
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

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Name;
		yield return Description;
		yield return Version ?? "";
	}

	public override string ToString()
	{
		return Name;
	}
}