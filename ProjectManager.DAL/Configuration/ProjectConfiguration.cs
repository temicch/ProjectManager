using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Configuration
{
    class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> modelBuilder)
        {
            modelBuilder
                .HasOne(x => x.Manager)
                .WithMany(x => x.ManagedProjects);
            modelBuilder
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder
                .Property(x => x.CustomerCompany)
                .HasMaxLength(100);
            modelBuilder
                .Property(x => x.PerformerCompany)
                .HasMaxLength(100);
            modelBuilder
                .Property(x => x.StartDate)
                .HasColumnType("Date")
                .IsRequired();
            modelBuilder
                .Property(x => x.EndDate)
                .HasColumnType("Date")
                .IsRequired();
        }
    }
}
