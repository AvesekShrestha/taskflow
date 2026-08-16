using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taskflow.Domain.Issue;
using Taskflow.Domain.Project;
using Taskflow.Domain.Shared.Interfaces;
using Taskflow.Domain.User;
using Taskflow.Infrastructure.Persistence;
using Taskflow.Infrastructure.Persistence.Repository;

namespace Taskflow.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    services.AddScoped<IUnitOfWork, UnitOfWork>();

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IProjectRepository, ProjectRepository>();
    services.AddScoped<IIssueRepository, IssueRepository>();

    return services;
  }
}
