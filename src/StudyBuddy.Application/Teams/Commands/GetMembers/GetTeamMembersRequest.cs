using StudyBuddy.Application.Teams.DTOs;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.GetMembers;

public record GetTeamMembersRequest(Guid TeamId) : IQuery<IEnumerable<MemberDto>>;