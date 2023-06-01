using StudyBuddy.Application.Users.Commands.ChangeEmail;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class ChangeEmailRequestHandler : ICommandHandler<ChangeEmailRequest>
{
    public Task Handle(ChangeEmailRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}