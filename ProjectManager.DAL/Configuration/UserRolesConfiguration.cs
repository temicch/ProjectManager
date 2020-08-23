using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Configuration
{
    public class UserRolesConfiguration: IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
        }

        static UserRolesConfiguration()
        {
            CreateEntities();
        }

        #region SeedData

        public static IList<IdentityUserRole<Guid>> Entities { get; private set; }

        private static void CreateEntities()
        {
            var leaderGuid = RolesConfiguration.EntityIds[0];
            var managerGuid = RolesConfiguration.EntityIds[1];
            var employeeGuid = RolesConfiguration.EntityIds[2];

            Entities = new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                {
                    RoleId = leaderGuid,
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = managerGuid,
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = managerGuid,
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = managerGuid,
                },
                new IdentityUserRole<Guid>()
                {
                    RoleId = employeeGuid,
                }
            };

            var employees = EmployeeConfiguration.Entities;
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].UserId = employees[i].Id;
            }
        }

        #endregion
    }
}
