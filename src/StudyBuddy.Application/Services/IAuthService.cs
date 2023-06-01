using StudyBuddy.Application.Users.Commands;
using StudyBuddy.Application.Users.Commands.Login;
using StudyBuddy.Application.Users.Commands.Register;

namespace StudyBuddy.Application.Services;

public interface IAuthService
{
    Task<LoginUserResponse> Login(LoginUserRequest request, CancellationToken cancellationToken = default);
    Task<RegisterUserResponse> Register(RegisterUserRequest request, CancellationToken cancellationToken = default);
}