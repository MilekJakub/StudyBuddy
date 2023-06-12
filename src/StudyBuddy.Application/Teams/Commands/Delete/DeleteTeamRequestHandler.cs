using System.Security.Claims;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Responses;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Commands.Delete;

public class DeleteTeamRequestHandler
    : ICommandHandler<DeleteTeamRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTeamRequestHandler(
        ITeamRepository teamRepository,
        IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _teamRepository = teamRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task Handle(
        DeleteTeamRequest request,
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
        
        var team = await _teamRepository
            .GetByIdAsync(new TeamId(request.Id), cancellationToken);
        
        if (team is null)
        {
            throw new TeamNotFoundException(request.Id.ToString());
        }

        var userMembership = team.Memberships.FirstOrDefault(x => x.UserId.Value == Guid.Parse(userId));

        if (userMembership is null && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamMemberException");
        }

        if (userMembership?.Role.Value != "Leader" && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamLeaderException");
        }
        
        await _teamRepository.RemoveAsync(team, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}