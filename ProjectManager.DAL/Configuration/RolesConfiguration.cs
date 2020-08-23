using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Configuration
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            SeedData(builder);
        }

        #region SeedData

        static RolesConfiguration()
        {
            EntityIds = new List<Guid>()
            {
                new Guid("e772e53e-c5e3-40d9-a6ff-c42781aa90c9"),
                new Guid("a0c254c7-4908-4b3f-8aee-ec0c3681b714"),
                new Guid("3bdec7ab-d4c3-4a59-985f-ec3261c89f84"),
            };
        }

        public static IList<Guid> EntityIds;

        private static void SeedData(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            var entities = new[]
            {
                new IdentityRole<Guid>()
                {
                    Name = "Leader",
                    ConcurrencyStamp = "7828c082-531d-48fa-ac76-be33ae985de7"
                },
                new IdentityRole<Guid>()
                {
                    Name = "Manager",
                    ConcurrencyStamp = "b57b2fcd-7b6f-43c0-b662-39089d635695"
                },
                new IdentityRole<Guid>()
                {
                    Name = "Employee",
                    ConcurrencyStamp = "a13457ca-d730-4343-8c4d-e2237f5329fb"
                }
            };

            for (int i = 0; i < entities.Length; i++)
                entities[i].Id = EntityIds[i];

            builder.HasData(entities);
        }

        #endregion
    }
}
