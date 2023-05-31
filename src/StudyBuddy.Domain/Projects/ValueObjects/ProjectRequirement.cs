using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectRequirement : ValueObject
{
	public ProjectRequirement(string requirement, string description)
	{
		// TODO: checks
		Name = requirement;
		Description = description;
	}

	public string Name { get; }
	public string Description { get; }
	
	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Name;
		yield return Description;
	}

	public override string ToString()
	{
		return Name;
	}
}