using StudyBuddy.Application.Users.Commands.ChangeRegisterNumber;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class ChangeRegisterNumberRequestHandler : ICommandHandler<ChangeRegisterNumberRequest>
{
    public Task Handle(ChangeRegisterNumberRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}