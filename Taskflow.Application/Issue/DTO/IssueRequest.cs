namespace Taskflow.Application.Issue.DTO;

public sealed record IssueRequest(
  string Title,
  string Description,
  string Priority,
  string Status
);
