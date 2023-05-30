using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.Events;

public record MembershipAddedToTeamEvent(Team Team, Membership Membership) : IDomainEvent;