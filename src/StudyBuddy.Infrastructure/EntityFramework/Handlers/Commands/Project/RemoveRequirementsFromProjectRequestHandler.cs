using StudyBuddy.Application.Projects.Commands.RemoveRequirements;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class RemoveRequirementsFromProjectRequestHandler : ICommandHandler<RemoveRequirementsFromProjectRequest>
{
    public Task Handle(RemoveRequirementsFromProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}