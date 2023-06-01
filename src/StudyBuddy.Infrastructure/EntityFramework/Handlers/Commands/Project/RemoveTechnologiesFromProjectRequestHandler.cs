using StudyBuddy.Application.Projects.Commands.RemoveTechnologies;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class RemoveTechnologiesFromProjectRequestHandler : ICommandHandler<RemoveTechnologiesFromProjectRequest>
{
    public Task Handle(RemoveTechnologiesFromProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}