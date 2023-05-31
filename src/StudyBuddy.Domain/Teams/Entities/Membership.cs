using StudyBuddy.Domain.Projects;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams.ValueObjects;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;
using StudyBuddy.Shared.Domain;

namespace StudyBuddy.Domain.Teams.Entities;

public class Membership : Entity<MembershipId>
{
	public Membership(
		MembershipId id,
		User member,
		MemberRole role,
		Project project,
		DateTime joinDate)
	{
		Id = id;
		MemberId = member.Id;
		Member = member;
		Role = role;
		ProjectId = project.Id;
		Project = project;
		JoinDate = joinDate;
	}

	public UserId MemberId { get; private set; }
	public User Member { get; private set; }
	public MemberRole Role { get; private set; }
	public ProjectId ProjectId { get; private set; }
	public Project Project { get; private set; }
	public DateTime JoinDate { get; private set; }

	// public void ChangeRole(MemberRole role)
	// public void QuitProject()
}