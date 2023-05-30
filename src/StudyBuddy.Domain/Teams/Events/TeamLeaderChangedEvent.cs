using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.Events;

public record TeamLeaderChangedEvent(Team Team, Membership Leader) : IDomainEvent;