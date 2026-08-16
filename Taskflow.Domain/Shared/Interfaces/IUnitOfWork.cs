namespace Taskflow.Domain.Shared.Interfaces;

public interface IUnitOfWork
{
  Task SaveChangesAsync();
}
