using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectDescription : ValueObject
{
	public ProjectDescription(string projectDescription)
	{
		// TODO: checks
		Value = projectDescription;
	}

	public string Value { get; set; }

	public override IEnumerable<object> GetAtomicValues()
	{
		throw new NotImplementedException();
	}

	public override string ToString()
	{
		return Value;
	}
}