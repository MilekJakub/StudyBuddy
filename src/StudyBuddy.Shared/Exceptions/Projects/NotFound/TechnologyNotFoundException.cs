using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Projects.NotFound;

public class TechnologyNotFoundException : NotFoundException
{
	public TechnologyNotFoundException(string name)
		: base($"The technology with name '{name}' was not found.")
	{
	}
}