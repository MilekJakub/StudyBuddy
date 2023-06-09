using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;

namespace StudyBuddy.Application.Teams.Commands.Update;

public class UpdateTeamRequestHandler : ICommandHandler<UpdateTeamRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateTeamRequestHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        UpdateTeamRequest request,
        CancellationToken cancellationToken)
    {
        if (!IsValid(request))
        {
            throw new Exception("Cannot update the project. No values provided.");
        }

        var team = await _teamRepository
            .GetByIdAsync(request.TeamId, cancellationToken);
        
        team.ChangeName(new TeamName(request.Name!));
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    
    public static bool IsValid(object? value)
    {
        if (value is null)
        {
            return false;
        }
        
        var typeInfo = value.GetType();

        var propertyInfo = typeInfo.GetProperties();

        return propertyInfo
            .Any(property => property.GetValue(value) is not null);
    }
}