using StudyBuddy.Application.Users.Commands.ChangeFirstname;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class ChangeFirstnameRequestHandler : ICommandHandler<ChangeFirstnameRequest>
{
    public Task Handle(ChangeFirstnameRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}