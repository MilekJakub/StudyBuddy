namespace StudyBuddy.Application.Users.DTOs;

public record UserDto(
    Guid Id,
    string Username,
    string Email,
    string Firstname,
    string Lastname,
    string RegisterNumber);