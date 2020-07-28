using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL
{
    public class ProjectDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployees> ProjectEmployees { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProjectEmployees>()
                .HasKey(t => new { t.EmployeeId, t.ProjectId });

            modelBuilder.Entity<ProjectEmployees>()
                .HasOne(sc => sc.Employee)
                .WithMany(s => s.ProjectEmployees);

            modelBuilder.Entity<ProjectEmployees>()
                .HasOne(sc => sc.Project)
                .WithMany(c => c.ProjectEmployees);


            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Tasks)
                .WithOne(e => e.Performer)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(c => c.Performer)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Employee>()
                .HasMany(c => c.TasksAuthor)
                .WithOne(e => e.Author)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(c => c.Author)
                .WithMany(e => e.TasksAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Employee>()
                .HasMany(c => c.ManagedProjects)
                .WithOne(e => e.Manager)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Project>()
                .HasOne(c => c.Manager)
                .WithMany(e => e.ManagedProjects)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Project>()
                .HasMany(c => c.Tasks)
                .WithOne(e => e.Project)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(c => c.Project)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
