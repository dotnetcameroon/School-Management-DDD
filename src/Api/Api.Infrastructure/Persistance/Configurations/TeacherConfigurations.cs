using Api.Domain.SchoolAggregate.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infrastructure.Persistance.Configurations;

public class TeacherConfigurations : IEntityTypeConfiguration<TeacherAdvisor>
{
    public void Configure(EntityTypeBuilder<TeacherAdvisor> builder)
    {
        builder.Navigation(c => c.Classes).Metadata.SetField("_classes");
        builder.Metadata.FindNavigation(nameof(TeacherAdvisor.Classes))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
