using StudyBuddy.Application.Users.Commands.ChangeLastname;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class ChangeLastnameRequestHandler : ICommandHandler<ChangeLastnameRequest>
{
    public Task Handle(ChangeLastnameRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}