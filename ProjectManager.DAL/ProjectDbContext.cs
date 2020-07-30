using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System.Linq;

namespace ProjectManager.DAL
{
    internal static class Extension
    {
        public static void DetachLocal<T>(this DbContext context, T t, int entryId)
           where T : class, IBaseEntity
        {
            var local = context.Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id == entryId);
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(t).State = EntityState.Modified;
        }
    }
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
                .HasKey(t => new {t.EmployeeId, t.ProjectId});

            modelBuilder.Entity<ProjectEmployees>()
                .HasOne(sc => sc.Employee)
                .WithMany(s => s.ProjectEmployees);

            modelBuilder.Entity<ProjectEmployees>()
                .HasOne(sc => sc.Project)
                .WithMany(c => c.ProjectEmployees);


            modelBuilder.Entity<ProjectTask>()
                .HasOne(c => c.Performer)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);


            modelBuilder.Entity<ProjectTask>()
                .HasOne(c => c.Author)
                .WithMany(e => e.TasksAuthor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);


            modelBuilder.Entity<Project>()
                .HasOne(c => c.Manager)
                .WithMany(e => e.ManagedProjects)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);

            modelBuilder.Entity<ProjectTask>()
                .HasOne(c => c.Project)
                .WithMany(e => e.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .IsRequired(false);
        }
    }
}