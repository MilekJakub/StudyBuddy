using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.Update;

public record UpdateTeamRequest(Guid TeamId, string? Name) : ICommand;