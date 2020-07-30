﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;

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