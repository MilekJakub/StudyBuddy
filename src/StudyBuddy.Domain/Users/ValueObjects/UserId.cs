using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;

namespace StudyBuddy.Domain.Users.ValueObjects;

public sealed record UserId : IValueObject
{
	private UserId()
	{
		// For Entity Framework	
	}
	
	public UserId(Guid id)
	{
		Value = id;
	}

	public Guid Value { get; }

	public override string ToString()
	{
		return Value.ToString();
	}
	
	public static implicit operator Guid(UserId id) => id.Value;
	public static implicit operator UserId(Guid id) => new(id);
}