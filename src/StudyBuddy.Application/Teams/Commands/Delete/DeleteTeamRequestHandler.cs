using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Commands.Delete;

public class DeleteTeamRequestHandler
    : ICommandHandler<DeleteTeamRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTeamRequestHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        DeleteTeamRequest request,
        CancellationToken cancellationToken)
    {
        var team = await _teamRepository
            .GetByIdAsync(new TeamId(request.Id), cancellationToken);

        if (team is null)
        {
            throw new TeamNotFoundException(request.Id.ToString());
        }
        
        await _teamRepository.RemoveAsync(team, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}