using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectTechnology : ValueObject
{
	public ProjectTechnology(string technology)
	{
		// TODO: checks
		Value = technology;
	}

	public string Value { get; set; }

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}

	public override string ToString()
	{
		return Value;
	}
}