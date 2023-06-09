using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Projects.NotFound;

public class ProjectNotFoundException : NotFoundException
{
    public ProjectNotFoundException(string id)
        : base($"The project with id '{id}' was not found.")
    {
    }
}