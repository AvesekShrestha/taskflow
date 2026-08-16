using Microsoft.EntityFrameworkCore;
using Taskflow.Domain.Issue;
using Taskflow.Domain.Project;
using Taskflow.Domain.User;

namespace Taskflow.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
  }
  public DbSet<UserAggregate> User { get; set; }
  public DbSet<ProjectAggregate> Project { get; set; }
  public DbSet<IssueAggregate> Issue { get; set; }


}

