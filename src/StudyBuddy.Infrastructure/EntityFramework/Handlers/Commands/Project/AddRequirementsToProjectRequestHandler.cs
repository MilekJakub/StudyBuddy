using StudyBuddy.Application.Projects.Commands.AddRequirements;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class AddRequirementsToProjectRequestHandler : ICommandHandler<AddRequirementsToProjectRequest>
{
    public Task Handle(AddRequirementsToProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}