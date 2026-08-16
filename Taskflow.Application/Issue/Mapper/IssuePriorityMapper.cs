using Taskflow.Domain.Issue;

namespace Taskflow.Application.Issue.Mapper;

public static class IssuePriorityMapper
{
  public static IssuePriority ToIssuePriority(string priority)
  {
    bool success = Enum.TryParse(
        priority,
        true,
        out IssuePriority Priority
        );

    if (!success) throw new InvalidOperationException("Invalid project member role");
    return Priority;
  }
}
