using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectId : IValueObject
{
	private ProjectId()
	{
		// For Entity Framework
	}

	public ProjectId(Guid id)
	{
		Value = id;
	}

	public Guid Value { get; }

	public override string ToString()
	{
		return Value.ToString();
	}
	
	public static implicit operator Guid(ProjectId id) => id.Value;
	public static implicit operator ProjectId(Guid id) => new(id);	
}