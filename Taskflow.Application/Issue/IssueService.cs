using Taskflow.Application.Issue.DTO;
using Taskflow.Application.Issue.DTO.Comments;
using Taskflow.Application.Issue.Mapper;
using Taskflow.Domain.Issue;
using Taskflow.Domain.Shared.Interfaces;

namespace Taskflow.Application.Issue;

public sealed class IssueService(IIssueRepository repository, IUnitOfWork unitOfWork) : IIssueService
{
  private readonly IIssueRepository _repository = repository;
  private readonly IUnitOfWork _unitOfWork = unitOfWork;

  public async Task<IssueResponse> AddCommentAsync(Guid issueId, CommentRequest request)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
      ??
      throw new KeyNotFoundException("No such issue");

    issue.AddComment(Guid.NewGuid(), request.Content, );
    await _repository.AddAsync(issue);
    await _unitOfWork.SaveChangesAsync();

    return issue.ToResponse();
  }

  public async Task<IssueResponse> AddIssueAsync(Guid projectId, IssueRequest request)
  {
    IssueStatus status = IssueStatusMapper.ToIssueStatus(request.Status);
    IssuePriority priority = IssuePriorityMapper.ToIssuePriority(request.Priority);
    IssueAggregate issue = IssueAggregate.Create(Guid.NewGuid(),
                                                 request.Title,
                                                 request.Description,
                                                 priority,
                                                 status,
                                                 projectId);
    await _repository.AddAsync(issue);
    await _unitOfWork.SaveChangesAsync();

    return issue.ToResponse();
  }

  public async Task<IssueResponse> AssignTaskAsync(Guid issueId, AssignUserRequest request)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
      ??
      throw new KeyNotFoundException("No such issue");

    issue.AssignTo(request.UserId);
    await _repository.AddAsync(issue);
    await _unitOfWork.SaveChangesAsync();

    return issue.ToResponse();
  }

  public async Task<IssueResponse> ChangePriorityAsync(Guid issueId, ChangePriorityRequest request)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
      ??
      throw new KeyNotFoundException("No such issue");

    IssuePriority priority = IssuePriorityMapper.ToIssuePriority(request.Priority);
    issue.ChangePriority(priority);

    await _repository.AddAsync(issue);
    await _unitOfWork.SaveChangesAsync();

    return issue.ToResponse();
  }

  public async Task<IssueResponse> ChangeStatusAsync(Guid issueId, ChangeStatusRequest request)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
          ??
          throw new KeyNotFoundException("No such issue");

    IssueStatus status = IssueStatusMapper.ToIssueStatus(request.Status);
    issue.ChangeStatus(status);

    await _repository.AddAsync(issue);
    await _unitOfWork.SaveChangesAsync();

    return issue.ToResponse();
  }

  public async Task<List<IssueResponse>> GetAllAsync()
  {
    List<IssueAggregate> issues = await _repository.GetAllAsync();
    return [.. issues.Select(issue => issue.ToResponse())];
  }

  public async Task<IssueResponse> GetByIdAsync(Guid issueId)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
              ??
              throw new KeyNotFoundException("No such issue");

    return issue.ToResponse();
  }

  public async Task RemoveCommentAsync(Guid issueId, Guid commentId)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
               ??
               throw new KeyNotFoundException("No such issue");

    issue.RemoveComment(commentId);

    await _repository.AddAsync(issue);
    await _unitOfWork.SaveChangesAsync();
  }

  public async Task RemoveIssueAsync(Guid issueId)
  {
    IssueAggregate issue = await _repository.GetByIdAsync(issueId)
               ??
               throw new KeyNotFoundException("No such issue");

    await _repository.RemoveAsync(issue);
  }
}
