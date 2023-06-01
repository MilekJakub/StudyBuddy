using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.Events;

public record MemberKickedFromProjectEvent(Team Team, Member Member) : IDomainEvent;