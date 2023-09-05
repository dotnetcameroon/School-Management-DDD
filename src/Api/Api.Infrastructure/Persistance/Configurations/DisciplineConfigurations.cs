using Api.Domain.AcademicAggregate.Entities;
using Api.Domain.AcademicAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class DisciplineConfigurations : IEntityTypeConfiguration<Discipline>
{
    public void Configure(EntityTypeBuilder<Discipline> builder)
    {
        builder.ToTable("Disciplines");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .HasConversion(
                id => id.Value,
                value => DisciplineId.Create(value)!
            );
        builder.Property(d => d.Title)
            .HasMaxLength(200);
        builder.HasIndex(d => d.Title);
        builder.HasOne(d => d.Semester);
    }
}
