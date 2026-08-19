using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taskflow.Application.Issue;
using Taskflow.Application.Issue.DTO;
using Taskflow.Application.Issue.DTO.Comments;

namespace Taskflow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class IssueController(IIssueService issueService) : ControllerBase
{

  private readonly IIssueService _issueService = issueService;


  [Authorize]
  [Route("{issueId}")]
  [HttpGet]
  public async Task<IActionResult> GetIssueById(Guid issueId)
  {
    IssueResponse result = await _issueService.GetByIdAsync(issueId);
    return Ok(result);
  }

  [Authorize]
  [Route("")]
  [HttpGet]
  public async Task<IActionResult> GetAllIssue()
  {
    List<IssueResponse> result = await _issueService.GetAllAsync();
    return Ok(result);
  }

  [Authorize]
  [Route("{issueId}/comment/{commentId}")]
  [HttpGet]
  public async Task<IActionResult> GetCommentById(Guid issueId, Guid commentId)
  {

    CommentResponse result = await _issueService.GetCommentById(issueId, commentId);
    return Ok(result);
  }

  [Authorize]
  [Route("{issueId}/comment")]
  [HttpGet]
  public async Task<IActionResult> GetAllComments(Guid issueId)
  {
    List<CommentResponse> result = await _issueService.GetCommentsByIssueIdAsync(issueId);
    return Ok(result);
  }


  [Authorize]
  [Route("")]
  [HttpPost]
  public async Task<IActionResult> CreateIssue(IssueRequest request)
  {

    string? userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
    if (!Guid.TryParse(userIdValue, out Guid userId))
      return Unauthorized();


    IssueResponse result = await _issueService.AddIssueAsync(userId, request);

    return CreatedAtAction(
        nameof(GetIssueById),
        new { issueId = result.Id },
        result
        );
  }

  [Authorize]
  [Route("{issueId}/comment")]
  [HttpPost]
  public async Task<IActionResult> AddComment(Guid issueId, CommentRequest request)
  {

    string? userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

    if (!Guid.TryParse(userIdValue, out Guid userId))
      return Unauthorized();

    IssueResponse result = await _issueService.AddCommentAsync(issueId, userId, request);
    return CreatedAtAction(
        nameof(GetCommentById),
        new { issueId, commentId = result.Id },
        result
        );
  }

  [Authorize]
  [Route("{issueId}/priority")]
  [HttpPatch]
  public async Task<IActionResult> ChangeIssuePriority(Guid issueId, ChangePriorityRequest request)
  {
    IssueResponse result = await _issueService.ChangePriorityAsync(issueId, request);
    return Ok(result);
  }

  [Authorize]
  [Route("{issueId}/status")]
  [HttpPatch]
  public async Task<IActionResult> ChangeIssueStatus(Guid issueId, ChangeStatusRequest request)
  {
    IssueResponse result = await _issueService.ChangeStatusAsync(issueId, request);
    return Ok(result);
  }

  [Authorize]
  [Route("{issueId}/assignee")]
  [HttpPatch]
  public async Task<IActionResult> AssignTask(Guid issueId, AssignUserRequest request)
  {
    IssueResponse result = await _issueService.AssignTaskAsync(issueId, request);
    return Ok(result);
  }

  [Authorize]
  [Route("{issueId}")]
  [HttpDelete]
  public async Task<IActionResult> RemoveIssue(Guid issueId)
  {
    await _issueService.RemoveIssueAsync(issueId);
    return Ok("Issue deleted successfully");
  }

  [Authorize]
  [Route("{issueId}/comment/{commentId}")]
  [HttpDelete]
  public async Task<IActionResult> RemoveIssue(Guid issueId, Guid commentId)
  {
    await _issueService.RemoveCommentAsync(issueId, commentId);
    return Ok("Comment deleted successfully");
  }

}
