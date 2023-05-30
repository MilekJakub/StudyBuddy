using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProjectDeadlineChangedEvent(Project Project, DateTime Deadline) : IDomainEvent;