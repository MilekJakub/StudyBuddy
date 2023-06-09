using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudyBuddy.Domain.Users;
using StudyBuddy.Domain.Users.ValueObjects;

namespace StudyBuddy.Infrastructure.EntityFramework.Configurations;

public class ApplicationDbContextConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(x => x.Username).IsUnique();
        
        builder
            .Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                id => new UserId(id))
            .HasColumnName("Id");
        
        builder
            .Property(u => u.Username)
            .HasConversion(
                username => username.ToString(),
                username => new Username(username))
            .HasColumnName("Username")
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasConversion(
                email => email.ToString(),
                email => new Email(email))
            .HasColumnName("Email")
            .IsRequired();

        builder
            .Property(u => u.PasswordHash)
            .HasConversion(
                hash => hash.ToString(),
                hash => new PasswordHash(hash))
            .HasColumnName("PasswordHash")
            .IsRequired();

        builder
            .Property(u => u.Role)
            .HasConversion(
                role => role.ToString(),
                role => new UserRole(role))
            .HasColumnName("Role")
            .IsRequired();

        builder
            .Property(u => u.Firstname)
            .HasConversion(
                firstname => firstname.ToString(),
                firstname => new Firstname(firstname))
            .HasColumnName("Firstname")
            .IsRequired();

        builder
            .Property(u => u.Lastname)
            .HasConversion(
                lastname => lastname.ToString(),
                lastname => new Lastname(lastname))
            .HasColumnName("Lastname")
            .IsRequired();

        builder
            .Property(u => u.RegisterNumber)
            .HasConversion(
                registerNumber => registerNumber.ToString(),
                registerNumber => new RegisterNumber(registerNumber))
            .HasColumnName("RegisterNumber")
            .IsRequired();

        builder
            .Property(u => u.CreatedAt)
            .HasColumnName("CreatedAt")
            .IsRequired();
        
        builder.ToTable("Users");
    }
}