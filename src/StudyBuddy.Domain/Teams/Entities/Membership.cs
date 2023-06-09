using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Teams.Entities;

public class Membership : Entity
{
	public Membership(
		MembershipId id,
		Team team,
		User user,
		ProjectRole role,
		DateTime joinDate)
	{
		Id = id;
		TeamId = team.Id;
		Team = team;
		UserId = user.Id;
		User = user;
		Role = role;
		JoinDate = joinDate;
	}

	public MembershipId Id { get; init; }
	public ProjectRole Role { get; private set; }
	public DateTime JoinDate { get; private set; }

	public TeamId TeamId { get; private set; }
	public Team Team { get; private set; }
	public UserId UserId { get; private set; }
	public User User { get; private set; }

	public void ChangeRole(ProjectRole role)
	{
		Role = role;
	}
	
	private Membership()
	{
		// For Entity Framework
	}
}