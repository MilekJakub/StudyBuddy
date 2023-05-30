namespace StudyBuddy.Shared.Exceptions.Responses;

public abstract class NotFoundException : Exception
{
	protected NotFoundException(string message) : base(message)
	{
	}
}