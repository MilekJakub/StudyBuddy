using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record MemberId : IValueObject
{
	private MemberId()
	{
		// For Entity Framework
	}

	public MemberId(Guid id)
	{
		Value = id;
	}
	
	public MemberId(string id)
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