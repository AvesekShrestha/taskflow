using Taskflow.Domain.Issue.Entity;
using Taskflow.Domain.Shared;

namespace Taskflow.Domain.Issue;

public sealed class IssueAggregate : AggregateRoot<Guid>
{

  private readonly List<Comment> _comments = new();
  // private readonly List<Guid> _assignedTo = new();

  public string Title { get; private set; }
  public string Description { get; private set; }
  public IssueStatus Status { get; private set; }
  public IssuePriority Priority { get; private set; }
  public Guid ProjectId { get; private set; }
  public Guid ReportedBy { get; private set; }
  public Guid? AssignedTo { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public IReadOnlyCollection<Comment> Comments => _comments.AsReadOnly();
  // public IReadOnlyCollection<Guid> AssignedTo => _assignedTo.AsReadOnly();

  private IssueAggregate(Guid id,
                         string title,
                         string description,
                         IssuePriority priority,
                         IssueStatus status,
                         Guid projectId,
                         Guid reportedBy) : base(id)
  {

    Title = title;
    Description = description;
    Status = status;
    Priority = priority;
    ProjectId = projectId;
    ReportedBy = reportedBy;
  }

  public static IssueAggregate Create(Guid id,
                                      string title,
                                      string description,
                                      IssuePriority priority,
                                      IssueStatus status,
                                      Guid projectId,
                                      Guid reportedBy)
  {
    return new IssueAggregate(id,
                              title,
                              description,
                              priority,
                              status,
                              projectId,
                              reportedBy);
  }

  public void AddComment(Guid commentId, string content, Guid userId)
  {
    Comment newComment = new(commentId, content, userId);
    _comments.Add(newComment);
  }

  public void RemoveComment(Guid id)
  {
    Comment existingComment = _comments.FirstOrDefault(commnet => commnet.Id == id)
      ??
      throw new KeyNotFoundException("No comment found");
    _comments.Remove(existingComment);
  }


  public void AssignTo(Guid userId)
  {
    AssignedTo = userId;
  }

  // public void AssignTo(Guid userId)
  // {
  //   if (_assignedTo.Contains(userId))
  //     throw new ArgumentException("User already assigned");
  //
  //   _assignedTo.Add(userId);
  // }
  //
  // public void Unassign(Guid userId)
  // {
  //   if (!_assignedTo.Contains(userId))
  //     throw new ArgumentException("User doesnot exists");
  //
  //   _assignedTo.Remove(userId);
  // }

  public void ChangeStatus(IssueStatus status)
  {
    Status = status;
  }

  public void ChangePriority(IssuePriority priority)
  {
    Priority = priority;
  }

}
