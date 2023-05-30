using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Users.BadRequest;

public class InvalidUserIdException : BadRequestException
{
	public InvalidUserIdException(string id) : base($"The user guid '{id}' is invalid.")
	{
	}
}