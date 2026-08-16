namespace Taskflow.Application.Issue.DTO.Comments;

public sealed record CommentResponse(
    Guid Id,
    string Content,
    Guid CommentedBy
);
