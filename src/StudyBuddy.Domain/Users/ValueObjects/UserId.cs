using Microsoft.EntityFrameworkCore;

namespace StudyBuddy.Domain.Users.ValueObjects;

[Keyless]
public sealed record UserId(Guid Value);