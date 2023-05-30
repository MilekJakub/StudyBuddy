using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record RequirementsAddedToProjectEvent(Project Project, IEnumerable<ProjectRequirement> Requirements) : IDomainEvent;