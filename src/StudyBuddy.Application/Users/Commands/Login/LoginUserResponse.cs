namespace StudyBuddy.Application.Users.Commands.Login;

public record LoginUserResponse(Guid Id, string Username, string Email, string Token);