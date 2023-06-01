using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record MemberRole : IValueObject
{
	private MemberRole()
	{
		// For Entity Framework
	}
	
	public MemberRole(string role)
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