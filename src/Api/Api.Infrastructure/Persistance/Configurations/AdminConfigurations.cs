using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class AdminConfigurations : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder.Property(a => a.Id)
            .HasConversion(id => id.Value,
            value => AdminId.Create(value)!);

        builder.HasMany(a => a.Students);

        builder.Navigation(c => c.Students).Metadata.SetField("_students");
        builder.Metadata.FindNavigation(nameof(Admin.Students))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
