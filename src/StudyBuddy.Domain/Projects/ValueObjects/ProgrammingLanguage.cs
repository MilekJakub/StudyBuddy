using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed class ProgrammingLanguage : ValueObject
{
	public ProgrammingLanguage(string language)
	{
		// TODO: checks
		Value = language;
	}

	public string Value { get; }

	public override IEnumerable<object> GetAtomicValues()
	{
		yield return Value;
	}

	public override string ToString()
	{
		return Value;
	}
}