using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record Technology : IValueObject
{
	public Technology(string name, string description, string? version)
	{
		// TODO: checks
		// null or empty
		// too long

		Name = name;
		Description = description;
		Version = version;
	}

	public string Name { get; init; }
	public string Description { get; init; }
	public string? Version { get; init; }

	public override string ToString() => Name;

	private Technology()
	{
		// For Entity Framework
	}
}