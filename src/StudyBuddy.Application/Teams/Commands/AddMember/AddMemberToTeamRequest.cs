using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.AddMember;

public record AddMemberToTeamRequest(Guid TeamId, Guid UserId, string Role) : ICommand;