using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.BadRequest;

public class InvalidMemberIdException : BadRequestException
{
	public InvalidMemberIdException(string id)
		: base($"The member guid '{id}' is invalid.")
	{
	}
}