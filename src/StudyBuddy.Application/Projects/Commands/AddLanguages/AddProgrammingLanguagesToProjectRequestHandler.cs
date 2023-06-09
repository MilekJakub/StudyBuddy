using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Projects.NotFound;

namespace StudyBuddy.Application.Projects.Commands.AddLanguages;

public class AddProgrammingLanguagesToProjectRequestHandler
    : ICommandHandler<AddProgrammingLanguagesToProjectRequest>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddProgrammingLanguagesToProjectRequestHandler(
        IProjectRepository projectRepository,
        IUnitOfWork unitOfWork)
    {
        _projectRepository = projectRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        AddProgrammingLanguagesToProjectRequest request,
        CancellationToken cancellationToken)
    {
        var project = await _projectRepository
            .GetByIdAsync(request.ProjectId, cancellationToken);
        
        if (project is null)
        {
            throw new ProjectNotFoundException(request.ProjectId.ToString());
        }
        
        var validLanguages = request.Languages
            .Select(l => new ProgrammingLanguage(l.LanguageName, l.Version));
        
        project.AddProgrammingLanguages(validLanguages);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}