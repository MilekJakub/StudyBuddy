using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.ChangeLeader;

public record ChangeTeamLeaderRequest(Guid TeamId, Guid LeaderId) : ICommand;