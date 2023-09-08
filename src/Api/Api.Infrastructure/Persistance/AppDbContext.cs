using Api.Domain.SchoolAggregate.Entities;

namespace Api.Infrastructure.Persistance;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<TeacherAdvisor> TeacherAdvisors { get; set; } = null!;
    public DbSet<Admin> Admins { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
