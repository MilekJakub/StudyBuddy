using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record TeamName : IValueObject
{
	private TeamName()
	{
		// For Entity Framework
	}
	
	public TeamName(string name)
	{
		// TODO: checks
		Value = name;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}