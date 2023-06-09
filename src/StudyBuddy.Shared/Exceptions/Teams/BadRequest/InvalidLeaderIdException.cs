using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.BadRequest;

public class InvalidLeaderIdException : BadRequestException
{
    public InvalidLeaderIdException(string id)
        : base($"The member with id '{id}' is not a team leader.")
    {
    }
}