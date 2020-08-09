using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Configuration
{
    class ProjectEmployeesConfiguration : IEntityTypeConfiguration<ProjectEmployees>
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
    }
}
