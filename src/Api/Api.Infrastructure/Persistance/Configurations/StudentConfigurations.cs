using Api.Domain.AcademicAggregate.ValueObjects;
using Api.Domain.SchoolAggregate;
using Api.Domain.SchoolAggregate.Entities;
using Api.Domain.SchoolAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class StudentConfigurations : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.Id)
            .HasConversion(
                id => id.Value,
                value => StudentId.Create(value)!
            );

        builder.OwnsMany(s => s.Notations, snb =>
        {
            snb.ToTable("Notations");
            snb.WithOwner().HasForeignKey("StudentId");
            snb.HasKey(n => n.Id);
            snb.Property(n => n.Id)
                .HasConversion(
                    id => id.Value,
                    value => NotationId.Create(value));

            snb.HasOne(n => n.Student)
                .WithMany(s => s.Notations);

            snb.HasOne(n => n.Subject);
        });
        builder.HasMany(s => s.Classes).WithMany(c => c.Students);

        builder.Navigation(s => s.Classes).Metadata.SetField("_classes");
        builder.Metadata.FindNavigation(nameof(Student.Classes))?
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
