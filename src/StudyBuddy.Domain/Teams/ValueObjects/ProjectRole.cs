using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record ProjectRole : IValueObject
{
	private ProjectRole()
	{
		// For Entity Framework
	}
	
	public ProjectRole(string role)
	{
		// TODO: checks
		Value = role;
	}

	public string Value { get; }

	public override string ToString()
	{
		return Value;
	}
}