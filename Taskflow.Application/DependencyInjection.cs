using Microsoft.Extensions.DependencyInjection;
using Taskflow.Application.Issue;
using Taskflow.Application.Project;
using Taskflow.Application.User;

namespace Taskflow.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IProjectService, ProjectService>();
    services.AddScoped<IIssueService, IssueService>();

    return services;
  }
}
