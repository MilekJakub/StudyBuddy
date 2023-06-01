using StudyBuddy.Application.Projects.Commands.ChangeDifficulty;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Infrastructure.EntityFramework.Handlers.Commands.Project;

public class ChangeProjectDifficultyRequestHandler : ICommandHandler<ChangeProjectDifficultyRequest>
{
    public Task Handle(ChangeProjectDifficultyRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}