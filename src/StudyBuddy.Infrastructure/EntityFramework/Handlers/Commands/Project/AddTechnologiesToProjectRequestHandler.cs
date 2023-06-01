using StudyBuddy.Application.Projects.Commands.AddTechnologies;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class AddTechnologiesToProjectRequestHandler : ICommandHandler<AddTechnologiesToProjectRequest>
{
    public Task Handle(AddTechnologiesToProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}