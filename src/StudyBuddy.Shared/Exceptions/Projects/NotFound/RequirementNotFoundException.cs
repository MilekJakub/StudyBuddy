using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Projects.NotFound;

public class RequirementNotFoundException : NotFoundException
{
	public RequirementNotFoundException(string name)
		: base($"The requirement with name '{name}' was not found.")
	{
	}
}