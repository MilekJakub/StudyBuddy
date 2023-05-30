using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProjectEstimatedTimeToFinishChangedEvent(Project Project, DateTime EstimatedTimeToFinish) : IDomainEvent;