using StudyBuddy.Application.Users.Commands.ChangePassword;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class ChangePasswordRequestHandler : ICommandHandler<ChangePasswordRequest>
{
    public Task Handle(ChangePasswordRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}