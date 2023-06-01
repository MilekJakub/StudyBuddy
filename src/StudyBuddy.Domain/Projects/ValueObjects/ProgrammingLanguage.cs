using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProgrammingLanguage : IValueObject
{
	private ProgrammingLanguage()
	{
		// For Entity Framework
	}
	
	public ProgrammingLanguage(string languageName, string? version)
	{
		// TODO: checks
		Name = languageName;
		Version = version;
	}

	public string Name { get; }
	public string? Version { get; }

	public override string ToString()
	{
		return Name;
	}
}