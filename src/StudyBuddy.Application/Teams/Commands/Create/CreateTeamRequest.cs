namespace StudyBuddy.Application.Teams.Commands.Create;

public record CreateTeamRequest(Guid Id, string Name, Guid UserId);