using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed class ProgrammingLanguage : ValueObject
{
	public ProgrammingLanguage(string languageName, string? version)
	{
		// TODO: checks
		Name = languageName;
		Version = version;
	}

	public string Name { get; }
	public string? Version { get; }

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Name;
		yield return Version ?? "";
	}

	public override string ToString()
	{
		return Name;
	}
}