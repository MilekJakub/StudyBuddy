namespace StudyBuddy.Shared.Exceptions.Responses;

public abstract class BadRequestException : Exception
{
	protected BadRequestException(string message) : base(message)
	{
	}
}