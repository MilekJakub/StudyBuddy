using StudyBuddy.Application.Users.Commands.ChangeUsername;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class ChangeUsernameRequestHandler : ICommandHandler<ChangeUsernameRequest>
{
    public Task Handle(ChangeUsernameRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}