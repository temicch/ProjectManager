using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
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

        static EmployeeConfiguration()
        {
            CreateEntities();
        }

        #region SeedData

        public static IList<Employee> Entities { get; private set; }

        private static void CreateEntities()
        {
            Entities = new[]
            {
                new Employee("user1@email.com")
                {
                    EmailConfirmed = true,
                    FirstName = "Zena",
                    LastName = "Hickman",
                    Surname = "",
                },
                new Employee("user2@email.com")
                {
                    EmailConfirmed = true,
                    FirstName = "Elodie",
                    LastName = "Rivas",
                    Surname = "",
                },
                new Employee("user3@email.com")
                {
                    EmailConfirmed = true,
                    FirstName = "Sierra",
                    LastName = "Woodley",
                    Surname = "",
                },
                new Employee("user4@email.com")
                {
                    EmailConfirmed = true,
                    FirstName = "Isla-Grace",
                    LastName = "Haworth",
                    Surname = "",
                },
                new Employee("user5@email.com")
                {
                    EmailConfirmed = true,
                    FirstName = "Beverley",
                    LastName = "Mason",
                    Surname = "",
                }
            };

            foreach (var entity in Entities)
            {
                entity.Id = Guid.NewGuid();
            }
        }
        
#endregion
    }
}
