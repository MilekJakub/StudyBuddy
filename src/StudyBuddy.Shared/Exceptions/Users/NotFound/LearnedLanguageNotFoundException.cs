using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Users.NotFound;

public class LearnedLanguageNotFoundException : NotFoundException
{
    public LearnedLanguageNotFoundException(string value) : base($"The programming language '{value}' was not found.")
    {
    }
}