using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Users.BadRequest;

public class EmailIsNotUniqueException : BadRequestException
{
    public EmailIsNotUniqueException(string email)
        : base($"The email address '{email}' is in use.")
    {
    }
}