namespace StudyBuddy.Application.Teams.Commands.KickMember;

public record KickTeamMemberRequest(Guid TeamId, Guid MembershipId);