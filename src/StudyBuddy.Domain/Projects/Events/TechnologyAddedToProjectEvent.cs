using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record TechnologyAddedToProjectEvent(Project Project, ProjectTechnology Technology) : IDomainEvent;