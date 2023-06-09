using StudyBuddy.Shared.Exceptions.Responses;

namespace StudyBuddy.Shared.Exceptions.Projects.NotFound;

public class LanguageNotFoundException : NotFoundException
{
	public LanguageNotFoundException(string name)
		: base($"The programming language with name '{name}' was not found.")
	{
	}
}