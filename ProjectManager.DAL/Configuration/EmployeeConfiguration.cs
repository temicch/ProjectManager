using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Configuration
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder
                    .Property(x => x.FirstName)
                    .HasMaxLength(24)
                    .IsRequired();
            modelBuilder
                    .Property(x => x.LastName)
                    .HasMaxLength(24)
                    .IsRequired();
            modelBuilder
                    .Property(x => x.Surname)
                    .HasMaxLength(24);
            modelBuilder
                    .Property(x => x.Email)
                    .HasMaxLength(256)
                    .IsRequired();
        }
    }
}
