using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.NotFound;

public class MembershipNotFoundException : NotFoundException
{
	public MembershipNotFoundException(string id)
		: base($"The member with id '{id}' was not found.")
	{
	}
}