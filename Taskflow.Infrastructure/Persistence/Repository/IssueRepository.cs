using Microsoft.EntityFrameworkCore;
using Taskflow.Domain.Issue;

namespace Taskflow.Infrastructure.Persistence.Repository;

public sealed class IssueRepository(AppDbContext db) : IIssueRepository
{
  private readonly AppDbContext _db = db;

  public async Task AddAsync(IssueAggregate issue)
  {
    await _db.Issue.AddAsync(issue);
  }

  public async Task<List<IssueAggregate>> GetAllAsync()
  {
    return await _db.Issue.ToListAsync();
  }

  public async Task<IssueAggregate?> GetByIdAsync(Guid id)
  {
    return await _db.Issue.FirstOrDefaultAsync(property => property.Id == id);
  }

  public async Task RemoveAsync(IssueAggregate issue)
  {
    _db.Issue.Remove(issue);
  }
}
