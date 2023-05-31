using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Users.Events;

public record UserRegisteredEvent(User User) : IDomainEvent;