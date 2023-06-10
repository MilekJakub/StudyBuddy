using Microsoft.EntityFrameworkCore;

namespace StudyBuddy.Domain.Teams.ValueObjects;

[Keyless]
public sealed record TeamId(Guid Value)
{
    public override string ToString()
    {
        return Value.ToString();
    }
}