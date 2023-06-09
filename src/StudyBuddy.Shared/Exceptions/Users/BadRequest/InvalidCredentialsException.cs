using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Users.BadRequest;

public class InvalidCredentialsException : BadRequestException
{
    public InvalidCredentialsException() : base($"Invalid username or password.")
    {
    }
}