using StudyBuddy.Shared.Domain;
using StudyBuddy.Shared.Domain.Interfaces;
using StudyBuddy.Shared.Exceptions.Users.BadRequest;

namespace StudyBuddy.Domain.Projects.ValueObjects;

public sealed record ProjectId(Guid Value);