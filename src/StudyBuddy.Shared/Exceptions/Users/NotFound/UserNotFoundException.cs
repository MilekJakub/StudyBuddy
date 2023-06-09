using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Users.NotFound;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string id)
        : base($"The user with id '{id}' was not found.")
    {
    }
}