using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.ChangeLeader;

public record ChangeTeamLeaderRequest(Guid TeamId, Guid NewLeaderMembershipId, string NewRoleForPreviousLeader) : ICommand;