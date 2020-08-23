using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Configuration
{
    public class ProjectEmployeesConfiguration : IEntityTypeConfiguration<ProjectEmployees>
    {
        public void Configure(EntityTypeBuilder<ProjectEmployees> modelBuilder)
        {
            modelBuilder
                .HasKey(t => new { t.EmployeeId, t.ProjectId });
            modelBuilder
                .HasOne(sc => sc.Employee)
                .WithMany(s => s.ProjectEmployees);
            modelBuilder
                .HasOne(sc => sc.Project)
                .WithMany(c => c.ProjectEmployees);
        }
        static ProjectEmployeesConfiguration()
        {
            CreateEntities();
        }

        #region SeedData

        public static IList<ProjectEmployees> Entities { get; private set; }

        private static void CreateEntities()
        {
            var projects = ProjectConfiguration.Entities;
            var employees = EmployeeConfiguration.Entities;

            Entities = new List<ProjectEmployees>(projects.Count);

            for (int i = 0; i < projects.Count; i++)
            {
                Entities.Add(new ProjectEmployees()
                {
                    ProjectId = projects[i].Id,
                    EmployeeId = employees[i % employees.Count].Id
                });
            }
        }

        #endregion
    }
}
