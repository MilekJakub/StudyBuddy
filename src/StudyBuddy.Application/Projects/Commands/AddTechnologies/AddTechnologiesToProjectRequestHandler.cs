using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Commands.AddTechnologies;

public class AddTechnologiesToProjectRequestHandler
    : ICommandHandler<AddTechnologiesToProjectRequest>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddTechnologiesToProjectRequestHandler(
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        AddTechnologiesToProjectRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(new ProjectId(request.ProjectId));
        
        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }

        var validTechnologies = request.Technologies
            .Select(t => new ProjectTechnology(t.Name, t.Description, t.Version));
        
        project.AddTechnologies(validTechnologies);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}