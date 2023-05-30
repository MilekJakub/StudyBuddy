using StudyBuddy.Domain.Projects;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Domain.Teams.Events;

public record CompletedProjectAddedToTeamEvent(Team Team, Project Project) : IDomainEvent;