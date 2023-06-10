using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Commands.Delete;

public class DeleteProjectRequestHandler
    : ICommandHandler<DeleteProjectRequest>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProjectRequestHandler(
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteProjectRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(new ProjectId(request.ProjectId), cancellationToken);

        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }

        await _projectRepository.RemoveAsync(project, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}