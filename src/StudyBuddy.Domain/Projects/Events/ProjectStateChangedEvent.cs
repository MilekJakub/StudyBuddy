using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProjectStateChangedEvent(Project Project, ProjectState ProjectState) : IDomainEvent;