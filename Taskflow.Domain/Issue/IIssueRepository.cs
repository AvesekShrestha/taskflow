namespace Taskflow.Domain.Issue;

public interface IIssueRepository
{
  Task<IssueAggregate?> GetByIdAsync(Guid id);
  Task<List<IssueAggregate>> GetAllAsync();
  Task AddAsync(IssueAggregate issue);
  Task RemoveAsync(IssueAggregate issue);
}
