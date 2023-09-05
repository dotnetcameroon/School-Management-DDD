using Api.Domain.Common.ValueObjects;
using Api.Domain.SchoolAggregate;
using Api.Domain.SchoolAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value)
            );

        builder.Property(u => u.Password)
            .HasConversion(
                pwd => pwd.Hash,
                hash => Password.CreateFromHash(hash));
    }
}
