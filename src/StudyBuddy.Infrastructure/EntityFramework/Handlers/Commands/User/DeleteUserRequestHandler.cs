using StudyBuddy.Application.Users.Commands.Delete;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.User;

public class DeleteUserRequestHandler : ICommandHandler<DeleteUserRequest>
{
    public Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}