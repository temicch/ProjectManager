using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL
{
    public class ProjectDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
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
                .WithMany(s => s.ProjectEmployees)
                .HasForeignKey(sc => sc.EmployeeId);

            modelBuilder.Entity<ProjectEmployees>()
                .HasOne(sc => sc.Project)
                .WithMany(c => c.ProjectEmployees)
                .HasForeignKey(sc => sc.ProjectId);

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.Tasks)
                .WithOne(e => e.Performer);
        }
    }
}
