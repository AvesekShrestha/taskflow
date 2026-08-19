namespace Taskflow.Application.Issue.DTO;

public sealed record IssueRequest(
  string Title,
  string Description,
  Guid ProjectId
);
