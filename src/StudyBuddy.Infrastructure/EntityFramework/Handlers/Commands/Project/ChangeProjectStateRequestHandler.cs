using StudyBuddy.Application.Projects.Commands.ChangeState;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class ChangeProjectStateRequestHandler : ICommandHandler<ChangeProjectStateRequest>
{
    public Task Handle(ChangeProjectStateRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}