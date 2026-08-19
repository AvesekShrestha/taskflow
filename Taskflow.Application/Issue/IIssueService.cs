using Taskflow.Application.Issue.DTO;
using Taskflow.Application.Issue.DTO.Comments;

namespace Taskflow.Application.Issue;

public interface IIssueService
{
  Task<IssueResponse> GetByIdAsync(Guid issueId);
  Task<List<IssueResponse>> GetAllAsync();
  Task<IssueResponse> AddIssueAsync(Guid userId, IssueRequest request);
  Task<IssueResponse> ChangePriorityAsync(Guid issueId, ChangePriorityRequest request);
  Task<IssueResponse> ChangeStatusAsync(Guid issueId, ChangeStatusRequest request);
  Task<IssueResponse> AddCommentAsync(Guid issueId, Guid userId, CommentRequest request);
  Task<IssueResponse> AssignTaskAsync(Guid issueId, AssignUserRequest request);
  Task<List<CommentResponse>> GetCommentsByIssueIdAsync(Guid issueId);
  Task<CommentResponse> GetCommentById(Guid issueId, Guid commentId);
  Task RemoveIssueAsync(Guid issueId);
  Task RemoveCommentAsync(Guid issueId, Guid commentId);
}
