using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record Deadline : IValueObject
{
    public Deadline(DateTime value)
    {
        // TODO: checks
        Value = value;
    }

    public DateTime Value { get; init; }

    private Deadline()
    {
        // For Entity Framework
    }
}