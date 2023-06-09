using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProgrammingLanguage : IValueObject
{
	public ProgrammingLanguage(string languageName, string? version)
	{
		// TODO: checks
		Name = languageName;
		Version = version;
	}

	public string Name { get; init; }
	public string? Version { get; init; }

	public override string ToString() => Name;

	private ProgrammingLanguage()
	{
		// For Entity Framework
	}
}