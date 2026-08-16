namespace Taskflow.Application.Project.DTO;

public sealed record MemberRequest(
    Guid UserId,
    string Role
);
