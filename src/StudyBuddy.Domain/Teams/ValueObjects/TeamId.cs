using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public sealed record TeamId : IValueObject
{
	private TeamId()
	{
		// For Entity Framework
	}

	public TeamId(Guid id)
	{
		Value = id;
	}

	public Guid Value { get; }

	public override string ToString()
	{
		return Value.ToString();
	}
	
	public static implicit operator Guid(TeamId id) => id.Value;
	public static implicit operator TeamId(Guid id) => new(id);	
}