using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyBuddy.Domain.Projects.ValueObjects;
using StudyBuddy.Domain.Teams;
using StudyBuddy.Domain.Teams.Entities;
using StudyBuddy.Domain.Teams.ValueObjects;

namespace StudyBuddy.Infrastructure.EntityFramework.Configurations;

public class TeamConfiguration
	: IEntityTypeConfiguration<Team>, 
	  IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.HasKey(t => t.Id);
        
	    builder
		    .Property(t => t.Id)
		    .HasConversion(
			    id => id.Value,
			    id => new TeamId(id));

	    builder
			.Property(t => t.Name)
			.HasConversion(
				name => name.ToString(),
				name => new TeamName(name))
			.HasColumnName("Name");
   
        builder
	        .Property(t => t.Description)
	        .HasConversion(
		        description => description.Value,
		        description => new TeamDescription(description))
	        .HasColumnName("Description");
        
		builder
			.HasMany(t => t.Memberships)
			.WithOne(m => m.Team)
			.HasForeignKey(m => m.TeamId);
		
		builder
			.HasMany(t => t.Projects)
			.WithOne(p => p.Team)
			.HasForeignKey(p => p.TeamId);
		
        builder.ToTable("Teams");
    }

    public void Configure(EntityTypeBuilder<Membership> builder)
    {
	    builder.HasKey(m => m.Id);
	    
	    builder
		    .Property(u => u.Id)
		    .HasConversion(
			    id => id.Value,
			    id => new MembershipId(id));
	    
	    builder
		    .Property(m => m.Role)
		    .HasConversion(
			    role => role.ToString(),
			    role => new ProjectRole(role))
		    .HasColumnName("Role")
		    .IsRequired();
	    
	    builder.Property(m => m.JoinDate)
		    .HasColumnName("JoinDate")
		    .IsRequired();

	    builder
		    .HasOne(m => m.Team)
		    .WithMany(t => t.Memberships)
		    .HasForeignKey(m => m.TeamId);
	    
	    builder
		    .HasOne(m => m.User)
		    .WithMany(u => u.Memberships)
		    .HasForeignKey(m => m.UserId);
	    
	    builder.ToTable("Memberships");
    }
}