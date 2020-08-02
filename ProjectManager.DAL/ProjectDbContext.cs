using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System.Collections.Generic;

namespace ProjectManager.DAL
{
    public class ProjectDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployees> ProjectEmployees { get; set; }

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

            modelBuilder.Entity<ProjectTask>()
                .HasOne(x => x.Author)
                .WithMany(x => x.TasksAuthor);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(x => x.Performer)
                .WithMany(x => x.Tasks);
            modelBuilder.Entity<ProjectTask>()
                .HasOne(x => x.Project)
                .WithMany(x => x.Tasks);

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Manager)
                .WithMany(x => x.ManagedProjects);
        }
    }
}