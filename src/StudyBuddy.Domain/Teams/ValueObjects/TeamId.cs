using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;

namespace StudyBuddy.Domain.Teams.ValueObjects;

public class TeamId : ValueObject, IEquatable<TeamId>
{
	public TeamId(string id)
	{
		Guid parsed;

		if(!Guid.TryParse(id, out parsed))
		{
			throw new InvalidTeamIdException(id);
		}

		Value = parsed;
	}

	public Guid Value { get; }

	public bool Equals(TeamId? other)
		=> other is not null && other.Value == Value;

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}

	public override string ToString()
	{
		return Value.ToString();
	}
}