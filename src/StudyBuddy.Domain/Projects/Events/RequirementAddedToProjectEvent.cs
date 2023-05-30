using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record RequirementAddedToProjectEvent(Project Project, ProjectRequirement Requirement) : IDomainEvent;