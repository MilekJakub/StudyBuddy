using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record TeamDescription : IValueObject
{
	public TeamDescription(string teamDescription)
	{
		// TODO: checks
		Value = teamDescription;
	}

	public string Value { get; init; }

	public override string ToString() => Value;

	private TeamDescription()
	{
		// For Entity Framework
	}
}