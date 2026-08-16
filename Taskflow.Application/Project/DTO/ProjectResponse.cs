using Taskflow.Domain.Project.Entity;

namespace Taskflow.Application.Project.DTO;

public sealed record ProjectResponse(
    Guid Id,
    string ProjectName,
    IReadOnlyCollection<ProjectMember> Members
);
