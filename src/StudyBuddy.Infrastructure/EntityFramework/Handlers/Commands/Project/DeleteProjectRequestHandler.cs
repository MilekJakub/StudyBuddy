using StudyBuddy.Application.Projects.Commands.Delete;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class DeleteProjectRequestHandler : ICommandHandler<DeleteProjectRequest>
{
    public Task Handle(DeleteProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}