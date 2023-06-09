using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Infrastructure.Time;

public class Clock : IClock
{
    public DateTime Current() => DateTime.UtcNow;
}