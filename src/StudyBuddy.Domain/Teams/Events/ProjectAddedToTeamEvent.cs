using StudyBuddy.Domain.Projects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.Events;

public record ProjectAddedToTeamEvent(
    Team Team,
    Project Project)
    : IDomainEvent;