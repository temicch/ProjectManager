using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Configuration
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
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

        static ProjectTaskConfiguration()
        {
            CreateEntities();
        }

        #region SeedData

        public static IList<ProjectTask> Entities { get; private set; }

        private static void CreateEntities()
        {
            Entities = new[]
            {
                new ProjectTask()
                {
                    Title = "Down-sized local intranet",
                    Comment =
                        "Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.",
                    Priority = 28
                },
                new ProjectTask()
                {
                    Title = "Open-source directional local area network",
                    Comment =
                        "Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.",
                    Priority = 26
                },
                new ProjectTask()
                {
                    Title = "Synergistic tertiary moderator",
                    Comment =
                        "In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.",
                    Priority = 89
                },
                new ProjectTask()
                {
                    Title = "Future-proofed impactful policy",
                    Comment =
                        "In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.",
                    Priority = 7
                },
                new ProjectTask()
                {
                    Title = "Total multimedia toolset",
                    Comment = "Pellentesque viverra pede ac diam.",
                    Priority = 5
                },
                new ProjectTask()
                {
                    Title = "Multi-tiered tangible task-force",
                    Comment =
                        "Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl.",
                    Priority = 76
                },
                new ProjectTask()
                {
                    Title = "Robust homogeneous benchmark",
                    Comment = "Donec dapibus.",
                    Priority = 28
                },
                new ProjectTask()
                {
                    Title = "Realigned high-level process improvement",
                    Comment =
                        "Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.",
                    Priority = 84
                },
                new ProjectTask()
                {
                    Title = "Centralized analyzing encryption",
                    Comment =
                        "Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.",
                    Priority = 22
                },
                new ProjectTask()
                {
                    Title = "Customizable incremental model",
                    Comment = "Nullam porttitor lacus at turpis.",
                    Priority = 60
                },
                new ProjectTask()
                {
                    Title = "User-friendly zero administration process improvement",
                    Comment =
                        "Suspendisse potenti. Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.",
                    Priority = 96
                },
                new ProjectTask()
                {
                    Title = "Centralized grid-enabled task-force",
                    Comment = "Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus.",
                    Priority = 60
                },
                new ProjectTask()
                {
                    Title = "Horizontal encompassing encoding",
                    Comment = "Aenean lectus. Pellentesque eget nunc.",
                    Priority = 22
                },
                new ProjectTask()
                {
                    Title = "Monitored transitional capability",
                    Comment =
                        "Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue.",
                    Priority = 79
                },
                new ProjectTask()
                {
                    Title = "Advanced mobile productivity",
                    Comment = "Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus.",
                    Priority = 12
                },
                new ProjectTask()
                {
                    Title = "Seamless 4th generation capacity",
                    Comment =
                        "Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.",
                    Priority = 25
                },
                new ProjectTask()
                {
                    Title = "Down-sized upward-trending extranet",
                    Comment =
                        "Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus.",
                    Priority = 18
                },
                new ProjectTask()
                {
                    Title = "Horizontal bandwidth-monitored ability",
                    Comment =
                        "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.",
                    Priority = 4
                },
                new ProjectTask()
                {
                    Title = "Multi-tiered cohesive capacity",
                    Comment = "Morbi ut odio. Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.",
                    Priority = 80
                },
                new ProjectTask()
                {
                    Title = "Team-oriented mission-critical encryption",
                    Comment = "Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.",
                    Priority = 11
                },
                new ProjectTask()
                {
                    Title = "Front-line object-oriented alliance",
                    Comment = "Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.",
                    Priority = 6
                },
                new ProjectTask()
                {
                    Title = "Cross-platform motivating system engine",
                    Comment = "Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl.",
                    Priority = 68
                },
                new ProjectTask()
                {
                    Title = "Fundamental eco-centric internet solution",
                    Comment =
                        "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.",
                    Priority = 81
                },
                new ProjectTask()
                {
                    Title = "Networked encompassing workforce",
                    Comment = "Curabitur gravida nisi at nibh.",
                    Priority = 1
                },
                new ProjectTask()
                {
                    Title = "User-friendly transitional monitoring",
                    Comment = "In sagittis dui vel nisl.",
                    Priority = 85
                },
                new ProjectTask()
                {
                    Title = "Intuitive leading edge algorithm",
                    Comment = "In hac habitasse platea dictumst. Maecenas ut massa quis augue luctus tincidunt.",
                    Priority = 65
                },
                new ProjectTask()
                {
                    Title = "Seamless 24/7 array",
                    Comment = "Nulla nisl.",
                    Priority = 81
                },
                new ProjectTask()
                {
                    Title = "Down-sized bifurcated moderator",
                    Comment = "Etiam pretium iaculis justo.",
                    Priority = 1
                },
                new ProjectTask()
                {
                    Title = "Persevering asynchronous extranet",
                    Comment = "Nulla suscipit ligula in lacus.",
                    Priority = 99
                },
                new ProjectTask()
                {
                    Title = "Reverse-engineered full-range solution",
                    Comment =
                        "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue.",
                    Priority = 61
                }
            };

            var employees = EmployeeConfiguration.Entities;
            var projects = ProjectConfiguration.Entities;
            var enumValues = Enum.GetValues(typeof(TaskStatus));

            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Id = Guid.NewGuid();
                Entities[i].Status = (TaskStatus)enumValues.GetValue(i % enumValues.Length);
                Entities[i].AuthorId = employees[i % employees.Count].Id;
                Entities[i].ProjectId = projects[i % projects.Count].Id;
                Entities[i].PerformerId = employees[(Entities.Count - i) % employees.Count].Id;
            }
        }

        #endregion
    }
}
