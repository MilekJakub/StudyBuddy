using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Users.NotFound;

public class LearnedTechnologyNotFoundException : NotFoundException
{
    public LearnedTechnologyNotFoundException(string value) : base($"The technology '{value}' was not found.")
    {
    }
}