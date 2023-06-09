using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Teams.NotFound;

public class LeaderNotFoundException : NotFoundException
{
    public LeaderNotFoundException()
        : base("The team leader was not found.")
    {
    }
}