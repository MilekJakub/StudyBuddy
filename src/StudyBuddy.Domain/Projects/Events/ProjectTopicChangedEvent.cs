using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProjectTopicChangedEvent(Project Project, ProjectTopic Topic) : IDomainEvent;