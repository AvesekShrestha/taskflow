using Taskflow.Domain.Issue;

namespace Taskflow.Application.Issue.Mapper;

public static class IssueStatusMapper
{
  public static IssueStatus ToIssueStatus(string status)
  {
    bool success = Enum.TryParse(
        status,
        true,
        out IssueStatus Status
        );

    if (!success) throw new InvalidOperationException("Invalid project member role");
    return Status;
  }
}
