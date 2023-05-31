namespace StudyBuddy.Application.Teams.Commands.AddCompletedProject;

public record AddCompletedProjectToTeamRequest(Guid TeamId, Guid ProjectId);