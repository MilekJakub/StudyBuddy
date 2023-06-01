using StudyBuddy.Application.Projects.Commands.ChangeTopic;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class ChangeProjectTopicRequestHandler : ICommandHandler<ChangeProjectTopicRequest>
{
    public Task Handle(ChangeProjectTopicRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}