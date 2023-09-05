using Api.Domain.SchoolAggregate.Entities;

namespace Api.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<TeacherAdvisor> TeacherAdvisors { get; set; } = null!;
}
