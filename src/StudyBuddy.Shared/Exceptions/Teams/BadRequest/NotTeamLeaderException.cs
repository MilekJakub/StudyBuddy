using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.BadRequest;

public class NotTeamLeaderException : BadRequestException
{
    public NotTeamLeaderException() : base("You are not a team leader. You cannot add new members to the team.")
    {
    }
}