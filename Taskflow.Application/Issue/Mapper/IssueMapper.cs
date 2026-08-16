using Taskflow.Application.Issue.DTO;
using Taskflow.Domain.Issue;

namespace Taskflow.Application.Issue.Mapper;


public static class IssueMapper
{
  public static IssueResponse ToResponse(this IssueAggregate issue)
  {
    return new IssueResponse(
        issue.Id,
        issue.Title,
        issue.Description,
        issue.Priority,
        issue.Status,
        issue.ReportedBy,
        issue.AssignedTo,
        issue.Comments
        );


  }
}
