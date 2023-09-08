using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class TeacherConfigurations : IEntityTypeConfiguration<TeacherAdvisor>
{
    public void Configure(EntityTypeBuilder<TeacherAdvisor> builder)
    {
        builder.Property(t => t.Id)
            .HasConversion(
                id => id.Value,
                value => TeacherAdvisorId.Create(value)!);

        builder.HasMany(t => t.Classes)
            .WithOne(c => c.TeacherAdvisor);

        builder.Navigation(c => c.Classes).Metadata.SetField("_classes");
        builder.Metadata.FindNavigation(nameof(TeacherAdvisor.Classes))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
