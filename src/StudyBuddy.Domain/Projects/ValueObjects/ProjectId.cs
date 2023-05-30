using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public class ProjectId : ValueObject, IEquatable<ProjectId>
{
	public ProjectId(string id)
	{
		Guid parsed;

		if(!Guid.TryParse(id, out parsed))
		{
			throw new InvalidUserIdException(id);
		}

		Value = parsed;
	}

	public Guid Value { get; }

	public bool Equals(ProjectId? other)
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