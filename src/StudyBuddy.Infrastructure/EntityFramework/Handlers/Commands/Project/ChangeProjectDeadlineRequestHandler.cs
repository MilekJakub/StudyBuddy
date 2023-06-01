using StudyBuddy.Application.Projects.Commands.ChangeDeadline;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class ChangeProjectDeadlineRequestHandler : ICommandHandler<ChangeProjectDeadlineRequest>
{
    public Task Handle(ChangeProjectDeadlineRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}