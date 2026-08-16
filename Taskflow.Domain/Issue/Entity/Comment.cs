using Taskflow.Domain.Shared;

namespace Taskflow.Domain.Issue.Entity;

public sealed class Comment : Entity<Guid>
{

  public string Content { get; private set; }
  public Guid UserId { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

  internal Comment(Guid id, string content, Guid userId) : base(id)
  {
    Content = content;
    UserId = userId;
  }

  internal Comment Create(Guid id, string content, Guid userId)
  {
    if (string.IsNullOrWhiteSpace(content))
      throw new ArgumentException("Invalid content");
    return new Comment(id, content, userId);
  }

  internal void UpdateContent(string content)
  {
    if (string.IsNullOrWhiteSpace(content))
      throw new ArgumentException("Invalid content");

    Content = content;
  }
}
