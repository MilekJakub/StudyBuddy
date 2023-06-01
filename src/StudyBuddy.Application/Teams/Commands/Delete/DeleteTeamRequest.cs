using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.Delete;

public record DeleteTeamRequest(Guid Id) : ICommand;