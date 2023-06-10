using Microsoft.EntityFrameworkCore;

namespace StudyBuddy.Domain.Users.ValueObjects;

[Keyless]
public sealed record UserId(Guid Value)
{
    public override string ToString()
    {
        return Value.ToString();
    }
}