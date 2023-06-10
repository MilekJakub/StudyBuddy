namespace StudyBuddy.Application.Teams.DTOs;

public record MemberDto(
    Guid MemberId,
    string Username,
    string Email,
    string Firstname,
    string Lastname,
    string RegisterNumber,
    string TeamName,
    string TeamRole,
    DateTime JoinDate);
