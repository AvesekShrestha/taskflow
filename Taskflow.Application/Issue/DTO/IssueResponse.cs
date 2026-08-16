using Taskflow.Domain.Issue;
using Taskflow.Domain.Issue.Entity;

namespace Taskflow.Application.Issue.DTO;

public sealed record IssueResponse(
  Guid Id,
  string Title,
  string Description,
  IssuePriority Priority,
  IssueStatus Status,
  Guid ReportedBy,
  Guid? AssignedTo,
  IReadOnlyCollection<Comment> Comments
);
