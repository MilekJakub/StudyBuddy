using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.NotFound;

public class TeamNotFoundException : NotFoundException
{
    public TeamNotFoundException(string id)
        : base($"The team with id '{id}' was not found.")
    {
    }
}