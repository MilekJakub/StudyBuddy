using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Projects.NotFound;

public class DifficultyNotFoundException : NotFoundException
{
    public DifficultyNotFoundException(string id) 
        : base($"The difficulty with id '{id}' was not found.")
    {
    }
}