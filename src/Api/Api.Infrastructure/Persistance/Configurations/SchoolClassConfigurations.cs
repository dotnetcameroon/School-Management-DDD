using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class SchoolClassConfigurations : IEntityTypeConfiguration<SchoolClass>
{
    public void Configure(EntityTypeBuilder<SchoolClass> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .HasConversion(
                id => id.Value,
                value => SchoolClassId.Create(value));
        builder.HasIndex(c => c.Specialization);
        builder.HasOne(c => c.TeacherAdvisor)
            .WithMany(t => t.Classes);
        builder.HasMany(c => c.Students)
            .WithMany(s => s.Classes);
    }
}
