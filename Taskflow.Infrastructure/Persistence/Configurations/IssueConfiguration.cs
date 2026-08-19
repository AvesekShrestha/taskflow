using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Issue;
using Taskflow.Domain.Project;
using Taskflow.Domain.User;

namespace Taskflow.Infrastructure.Persistence.Configurations;

public sealed class IssueConfiguration : IEntityTypeConfiguration<IssueAggregate>
{
  public void Configure(EntityTypeBuilder<IssueAggregate> builder)
  {
    builder.ToTable("Issue");
    builder.HasKey(key => key.Id);
    builder.Property(property => property.Id).ValueGeneratedNever();


    builder.HasOne<ProjectAggregate>()
      .WithMany()
      .HasForeignKey(key => key.ProjectId)
      .OnDelete(DeleteBehavior.Cascade);

    builder.HasOne<UserAggregate>()
      .WithMany()
      .HasForeignKey(key => key.ReportedBy)
      .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne<UserAggregate>()
      .WithMany()
      .HasForeignKey(key => key.AssignedTo)
      .OnDelete(DeleteBehavior.Restrict);

    builder.OwnsMany(property => property.Comments, comment =>
    {
      comment.HasKey(key => key.Id);
      comment.Property(property => property.Id).ValueGeneratedNever();
    });

  }
}
