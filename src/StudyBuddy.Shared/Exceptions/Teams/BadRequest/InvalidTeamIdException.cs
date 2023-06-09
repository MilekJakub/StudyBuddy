using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.BadRequest;

public class InvalidTeamIdException : BadRequestException
{
	public InvalidTeamIdException(string id)
		: base($"The team guid '{id}' is invalid.")
	{
	}
}