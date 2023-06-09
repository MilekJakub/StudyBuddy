using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record MembershipId : IValueObject
{
	private MembershipId()
	{
		// For Entity Framework
	}

	public MembershipId(Guid id)
	{
		Value = id;
	}
	
	public MembershipId(string id)
	{
		if(!Guid.TryParse(id, out var parsed))
		{
			throw new InvalidMemberIdException(id);
		}

		Value = parsed;
	}

	public Guid Value { get; }

	public override string ToString()
	{
		return Value.ToString();
	}
}