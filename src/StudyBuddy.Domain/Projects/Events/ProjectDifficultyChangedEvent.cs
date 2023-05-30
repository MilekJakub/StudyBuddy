using StudyBuddy.Domain.Projects.Enums;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Projects.Events;

public record ProjectDifficultyChangedEvent(Project Project, ProjectDifficulty Difficulty) : IDomainEvent;