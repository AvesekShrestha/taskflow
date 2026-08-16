using Taskflow.Application.Issue.DTO;
using Taskflow.Application.Issue.DTO.Comments;

namespace Taskflow.Application.Issue;

public interface IIssueService
{
  Task<IssueResponse> GetByIdAsync(Guid issueId);
  Task<List<IssueResponse>> GetAllAsync();
  Task<IssueResponse> AddIssueAsync(Guid projectId, IssueRequest request);
  Task<IssueResponse> ChangePriorityAsync(Guid issueId, ChangePriorityRequest request);
  Task<IssueResponse> ChangeStatusAsync(Guid issueId, ChangeStatusRequest request);
  Task<IssueResponse> AddCommentAsync(Guid issueId, CommentRequest request);
  Task<IssueResponse> AssignTaskAsync(Guid issueId, AssignUserRequest request);
  Task RemoveIssueAsync(Guid issueId);
  Task RemoveCommentAsync(Guid commentId);
}
