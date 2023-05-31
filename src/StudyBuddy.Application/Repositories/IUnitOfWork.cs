namespace StudyBuddy.Application.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}