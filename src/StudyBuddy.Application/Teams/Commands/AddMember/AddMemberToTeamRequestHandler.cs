using System.Security.Claims;
using StudyBuddy.Application.Services;
using StudyBuddy.Domain.Repositories;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Application.Interfaces;
using StudyBuddy.Shared.Exceptions.Responses;
using StudyBuddy.Shared.Exceptions.Teams.BadRequest;
using StudyBuddy.Shared.Exceptions.Teams.NotFound;

namespace StudyBuddy.Application.Teams.Commands.AddMember;

public class AddMemberToTeamRequestHandler
    : ICommandHandler<AddMemberToTeamRequest>
{
    private readonly ITeamRepository _teamRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddMemberToTeamRequestHandler(
        ITeamRepository teamRepository,
        IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _teamRepository = teamRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(
        AddMemberToTeamRequest request,
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
            .GetByIdAsync(new TeamId(request.TeamId), cancellationToken);
            
        if (team is null)
        {
            throw new TeamNotFoundException(request.TeamId.ToString());
        }
        
        var userMembership = team.Memberships.FirstOrDefault(x => x.UserId.Value.ToString() == userId);

        if (userMembership is null && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamMemberException");
        }

        if (userMembership?.UserId != team.GetLeader().UserId && !isAdminOrTeacher)
        {
            throw new Exception("NotTeamLeaderException");
        }
        
        var userToAdd = await _userRepository
            .GetByUsernameAsync(new Username(request.Username), cancellationToken);

        var newMembership = new Membership(
            id: new MembershipId(Guid.NewGuid()),
            team: team,
            user: userToAdd,
            role: new ProjectRole(request.Role),
            joinDate: DateTime.UtcNow);
        
        team.AddMember(newMembership);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}