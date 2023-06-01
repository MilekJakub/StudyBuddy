using StudyBuddy.Application.Projects.Commands.ChangeEstimatedTimeToFinish;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class ChangeProjectEstimatedTimeToFinishRequestHandler : ICommandHandler<ChangeProjectEstimatedTimeToFinishRequest>
{
    public Task Handle(ChangeProjectEstimatedTimeToFinishRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}