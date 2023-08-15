using Microsoft.EntityFrameworkCore;

namespace WebMvcProject.Data
{
  public class ProjectDbContext:DbContext
  {
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

      optionsBuilder.UseSqlServer("Server=DESKTOP-9OJGC9H;Database=CourseDb;Trusted_Connection=True;");

      base.OnConfiguring(optionsBuilder);
    }

  }
}
