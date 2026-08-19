using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taskflow.Domain.User;

namespace Taskflow.Infrastructure.Persistence.Configurations;

public sealed class UserConfiguration : IEntityTypeConfiguration<UserAggregate>
{
  public void Configure(EntityTypeBuilder<UserAggregate> builder)
  {
    builder.ToTable("User");
    builder.HasKey(key => key.Id);

    builder.ComplexProperty(property => property.Username, username =>
    {
      username.Property(x => x.Value)
      .HasMaxLength(30)
      .HasColumnName("Username")
      .IsRequired(true);
    });

    builder.ComplexProperty(property => property.Email, email =>
    {
      email.Property(x => x.Value)
      .HasColumnName("Email")
      .IsRequired(true);
    });

    builder.ComplexProperty(property => property.Password, password =>
    {
      password.Property(x => x.Value)
      .HasColumnName("Password")
      .IsRequired(true);
    });

  }
}
