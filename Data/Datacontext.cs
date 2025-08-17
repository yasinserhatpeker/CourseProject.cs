using Microsoft.EntityFrameworkCore;

namespace efCore.Data;

public class DataContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();

    public DbSet<Course> Courses => Set<Course>();
    
    public DbSet<CourseApply> CourseApplies => Set<CourseApply>();

}