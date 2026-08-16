using Taskflow.Domain.Shared.Interfaces;
namespace Taskflow.Infrastructure.Persistence;

public sealed class UnitOfWork(AppDbContext db) : IUnitOfWork
{
  private readonly AppDbContext _db = db;

  public async Task SaveChangesAsync()
  {
    await _db.SaveChangesAsync();
  }
}
