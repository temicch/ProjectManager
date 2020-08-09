using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Configuration
{
    class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> modelBuilder)
        {
            modelBuilder
                .HasOne(x => x.Author)
                .WithMany(x => x.TasksAuthor);
            modelBuilder
                .HasOne(x => x.Performer)
                .WithMany(x => x.Tasks);
            modelBuilder
                .HasOne(x => x.Project)
                .WithMany(x => x.Tasks);

            modelBuilder
                .Property(x => x.Title)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder
                .Property(x => x.Comment)
                .HasMaxLength(512);
        }
    }
}
