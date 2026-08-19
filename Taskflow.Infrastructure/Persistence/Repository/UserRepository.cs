using Taskflow.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Taskflow.Infrastructure.Persistence.Repository;

public sealed class UserRepository(AppDbContext db) : IUserRepository
{
  private readonly AppDbContext _db = db;

  public async Task AddAsync(UserAggregate user)
  {
    await _db.User.AddAsync(user);
  }

  public async Task<List<UserAggregate>> GetAllAsync()
  {
    return _db.User.ToList();
  }

  public async Task<UserAggregate?> GetByEmailAsync(string email)
  {
    return await _db.User.FirstOrDefaultAsync(u => u.Email.Value == email);
  }

  public async Task<UserAggregate?> GetByIdAsync(Guid id)
  {
    return await _db.User.FirstOrDefaultAsync(u => u.Id == id);
  }

  public async Task RemoveAsync(UserAggregate user)
  {
    _db.User.Remove(user);
  }
}
