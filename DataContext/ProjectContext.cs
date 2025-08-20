using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.DataContext
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(student =>
            {
                student.ToTable("Students");
                student.HasKey(s => s.Id);
                student.HasIndex(s => s.Identification).IsUnique();
                student.Property(s => s.Identification).IsRequired().HasMaxLength(10);
                student.Property(s => s.LastName).IsRequired().HasMaxLength(50);
                student.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Teacher>(teacher =>
            {
                teacher.ToTable("Teachers");
                teacher.HasKey(t => t.Id);
                teacher.HasIndex(t => t.Identification).IsUnique();
                teacher.Property(t => t.Identification).IsRequired().HasMaxLength(10);
                teacher.Property(t => t.LastName).IsRequired().HasMaxLength(50);
                teacher.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(course =>
            {
                course.ToTable("Courses");
                course.HasKey(c => c.Id);
                course.HasIndex(c => c.Name).IsUnique();
                course.Property(c => c.Name).IsRequired().HasMaxLength(50);
                course.Property(c => c.Description).IsRequired(false).HasMaxLength(200);
                course.Property(c => c.Credits).IsRequired();
                course.HasOne(c => c.Teacher).WithMany(c => c.Courses).HasForeignKey(c => c.TeacherId);
            });


            modelBuilder.Entity<Grade>(grade =>
            {
                grade.ToTable("Grades");
                grade.HasKey(g => g.Id);
                grade.HasIndex(g => new { g.StudentId, g.CourseId }).IsUnique();
                grade.Property(g => g.Score).IsRequired();
                grade.HasOne(g => g.Student).WithMany(g => g.Grades).HasForeignKey(g => g.StudentId);
                grade.HasOne(g => g.Course).WithMany(g => g.Grades).HasForeignKey(g => g.CourseId);
            });


        }

    }

}
