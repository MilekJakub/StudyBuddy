using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.NotFound;

public class MemberNotFoundException : NotFoundException
{
	public MemberNotFoundException(string id) : base($"The member with id '{id}' was not found.")
	{
	}
}