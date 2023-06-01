using StudyBuddy.Application.Projects.Commands.ChangeDescription;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class ChangeProjectDescriptionRequestHandler : ICommandHandler<ChangeProjectDescriptionRequest>
{
    public Task Handle(ChangeProjectDescriptionRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}