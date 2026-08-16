using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.Project;

namespace Taskflow.Infrastructure.Persistence.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<ProjectAggregate>
{
  public void Configure(EntityTypeBuilder<ProjectAggregate> builder)
  {
    builder.HasKey(key => key.Id);

    builder.OwnsMany(
        project => project.Members,
        member =>
        {
          member.HasKey(key => key.Id);

          member.Property(property => property.Id).ValueGeneratedNever();

          member.Property(property => property.UserId)
            .IsRequired(true);

          member.Property(property => property.Role)
            .IsRequired(true);

          member.Property(property => property.JoinedAt)
            .IsRequired(true);
        }
        );
  }
}
