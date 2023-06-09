namespace StudyBuddy.Domain.Projects.ValueObjects;

public record EstimatedTime
{
    public EstimatedTime(int days, int hours, int minutes, int seconds)
    {
        // TODO: checks
        Value = new TimeSpan(days, hours, minutes, seconds);
    }
    
    public EstimatedTime(TimeSpan value)
    {
        Value = value;
    }

    public TimeSpan Value { get; init; }

    private EstimatedTime()
    {
        // For EntityFramework
    }
}