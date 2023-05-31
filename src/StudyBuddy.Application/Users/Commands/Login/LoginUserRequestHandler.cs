using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Users.Commands.LoginUser;

public class LoginUserRequestHandler : ICommandHandler<LoginUserRequest>
{
    public Task Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        throw new Exception();
    }
}