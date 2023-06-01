using StudyBuddy.Application.Projects.Commands.AddProgrammingLanguages;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class AddProgrammingLanguagesToProjectRequestHandler : ICommandHandler<AddProgrammingLanguagesToProjectRequest>
{
    public Task Handle(AddProgrammingLanguagesToProjectRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}