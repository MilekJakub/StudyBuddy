namespace StudyBuddy.Application.Teams.Commands.ChangeName;

public record ChangeTeamNameRequest(Guid TeamId, string Name);