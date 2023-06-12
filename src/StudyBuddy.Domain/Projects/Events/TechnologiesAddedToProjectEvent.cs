using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record TechnologiesAddedToProjectEvent(Project Project, IEnumerable<Technology> Technologies) : IDomainEvent;