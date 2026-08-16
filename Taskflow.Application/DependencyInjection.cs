using Microsoft.Extensions.DependencyInjection;
using Taskflow.Application.Project;
using Taskflow.Application.User;

namespace Taskflow.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IProjectService, ProjectService>();

    return services;
  }
}
