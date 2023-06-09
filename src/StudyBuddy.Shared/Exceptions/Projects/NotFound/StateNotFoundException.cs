using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Projects.NotFound;

public class StateNotFoundException : NotFoundException
{
    public StateNotFoundException(string id) : base($"The state with id '{id}' was not found.")
    {
    }
}