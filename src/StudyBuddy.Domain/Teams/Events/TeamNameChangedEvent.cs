using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.Events;

public record TeamNameChangedEvent(Team Team, TeamName Name) : IDomainEvent;