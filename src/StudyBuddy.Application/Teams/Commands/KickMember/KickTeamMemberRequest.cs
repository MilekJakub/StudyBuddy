using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.KickMember;

public record KickTeamMemberRequest(Guid TeamId, Guid MemberId) : ICommand;