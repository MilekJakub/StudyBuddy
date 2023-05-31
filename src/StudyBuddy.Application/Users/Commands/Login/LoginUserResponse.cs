namespace StudyBuddy.Application.Users.Commands.LoginUser;

public record LoginUserResponse(Guid Id, string Username, string Email, string Token);