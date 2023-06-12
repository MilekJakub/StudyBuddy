using System.Security.Claims;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Responses;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

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
        var claims = request.GetClaims();
        var userId = claims.FirstOrDefault(x => x.Type == "userId")?.Value;
        var role = claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        var isAdminOrTeacher = role is "admin" or "teacher";

        if (userId is null && !isAdminOrTeacher)
        {
            throw new UnauthorizedException();
        }
        
        if (!IsValid(request))
        {
            throw new Exception("Cannot update the project. No values provided.");
        }

        var team = await _teamRepository
            .GetByIdAsync(new TeamId(request.TeamId), cancellationToken);

        if (team is null)
        {
            throw new TeamNotFoundException(request.TeamId.ToString());
        }
        
        var userMembership = team.Memberships.FirstOrDefault(x => x.UserId.Value == Guid.Parse(userId));

        if (userMembership is null && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamMemberException");
        }

        if (userMembership?.UserId != team.GetLeader().UserId && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamLeaderException");
        }

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