using StudyBuddy.Application.Projects.Commands.RemoveProgrammingLanguages;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class RemoveProgrammingLanguagesFromProjectRequestHandler : ICommandHandler<RemoveProgrammingLanguagesFromProjectRequest>
{
    public Task Handle(RemoveProgrammingLanguagesFromProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}