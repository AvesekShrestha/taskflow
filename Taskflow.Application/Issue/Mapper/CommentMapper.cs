using Taskflow.Application.Issue.DTO.Comments;
using Taskflow.Domain.Issue.Entity;

namespace Taskflow.Application.Issue.Mapper;


public static class CommentMapper
{
  public static CommentResponse ToResponse(this Comment comment)
  {
    return new CommentResponse(
      comment.Id,
      comment.Content,
      comment.UserId,
      comment.CreatedAt
  );
  }
}
