using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record MembershipId(Guid Value) : IValueObject
{
	public override string ToString()
	{
		return Value.ToString();
	}
}