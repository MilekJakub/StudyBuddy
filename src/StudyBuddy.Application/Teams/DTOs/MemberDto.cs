namespace StudyBuddy.Application.Teams.DTOs;

public record MemberDto(
    Guid MembershipId,
    string Username,
    string Email,
    string Firstname,
    string Lastname,
    string RegisterNumber,
    string TeamRole,
    DateTime JoinDate);
