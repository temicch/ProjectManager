using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProjectManager.DAL.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
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

        static ProjectConfiguration()
        {
            CreateEntities();
        }

        #region SeedData

        public static IList<Project> Entities { get; private set; }

        private static void CreateEntities()
        {
            Entities = new[]
            {
                new Project()
                {
                    Title = "Cookley",
                    CustomerCompany = "Raynor Group",
                    PerformerCompany = "Schroeder LLC",
                    StartDate = Convert.ToDateTime("2/20/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("1/12/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 29
                },
                new Project()
                {
                    Title = "Kanlam",
                    CustomerCompany = "Morar Inc",
                    PerformerCompany = "Murphy, Emmerich and Muller",
                    StartDate = Convert.ToDateTime("3/8/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("7/16/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 51
                },
                new Project()
                {
                    Title = "Transcof",
                    CustomerCompany = "Bosco, Zulauf and Lueilwitz",
                    PerformerCompany = "Terry-Doyle",
                    StartDate = Convert.ToDateTime("1/3/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("7/23/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 7
                },
                new Project()
                {
                    Title = "Sonair",
                    CustomerCompany = "Bernhard-Mann",
                    PerformerCompany = "Rippin, Koch and Schowalter",
                    StartDate = Convert.ToDateTime("1/30/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("10/9/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 99
                },
                new Project()
                {
                    Title = "Keylex",
                    CustomerCompany = "Stroman Group",
                    PerformerCompany = "Mayer, Klocko and McKenzie",
                    StartDate = Convert.ToDateTime("7/18/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("2/27/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 99
                },
                new Project()
                {
                    Title = "Tin",
                    CustomerCompany = "Runolfsdottir-Kassulke",
                    PerformerCompany = "SchneIder, Kreiger and Kling",
                    StartDate = Convert.ToDateTime("1/24/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("8/11/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 22
                },
                new Project()
                {
                    Title = "Sonair",
                    CustomerCompany = "Weimann, Purdy and Kessler",
                    PerformerCompany = "Rodriguez-Gorczany",
                    StartDate = Convert.ToDateTime("5/3/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("3/15/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 6
                },
                new Project()
                {
                    Title = "Andalax",
                    CustomerCompany = "Moen, Lesch and Dooley",
                    PerformerCompany = "Klocko Group",
                    StartDate = Convert.ToDateTime("9/12/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("10/21/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 71
                },
                new Project()
                {
                    Title = "Tampflex",
                    CustomerCompany = "Hessel-Feil",
                    PerformerCompany = "Blick, Bartoletti and Treutel",
                    StartDate = Convert.ToDateTime("9/14/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("9/25/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 58
                },
                new Project()
                {
                    Title = "Otcom",
                    CustomerCompany = "Leffler, Dicki and Wisoky",
                    PerformerCompany = "Tillman, McGlynn and Gislason",
                    StartDate = Convert.ToDateTime("9/1/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("5/30/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 31
                },
                new Project()
                {
                    Title = "Cookley",
                    CustomerCompany = "Walsh Inc",
                    PerformerCompany = "Mann, Gleason and Terry",
                    StartDate = Convert.ToDateTime("11/19/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("2/16/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 24
                },
                new Project()
                {
                    Title = "Quo Lux",
                    CustomerCompany = "Bashirian, Windler and Sipes",
                    PerformerCompany = "Bergnaum-Rowe",
                    StartDate = Convert.ToDateTime("8/12/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("4/1/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 65
                },
                new Project()
                {
                    Title = "Hatity",
                    CustomerCompany = "Mosciski LLC",
                    PerformerCompany = "Runolfsson-Zemlak",
                    StartDate = Convert.ToDateTime("1/14/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("6/8/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 27
                },
                new Project()
                {
                    Title = "Tin",
                    CustomerCompany = "Bashirian, Volkman and Becker",
                    PerformerCompany = "Shanahan, SchmIdt and Thiel",
                    StartDate = Convert.ToDateTime("10/25/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("9/24/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 40
                },
                new Project()
                {
                    Title = "Namfix",
                    CustomerCompany = "Zboncak-Block",
                    PerformerCompany = "Stracke-White",
                    StartDate = Convert.ToDateTime("4/27/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("11/8/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 88
                },
                new Project()
                {
                    Title = "Job",
                    CustomerCompany = "Moen, Willms and Wuckert",
                    PerformerCompany = "Boehm, Morissette and Zulauf",
                    StartDate = Convert.ToDateTime("11/14/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("9/13/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 20
                },
                new Project()
                {
                    Title = "Tempsoft",
                    CustomerCompany = "Powlowski-Thompson",
                    PerformerCompany = "Klein LLC",
                    StartDate = Convert.ToDateTime("1/25/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("11/15/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 3
                },
                new Project()
                {
                    Title = "Zamit",
                    CustomerCompany = "Pfeffer, Goyette and Spinka",
                    PerformerCompany = "Mayert, Mante and Dietrich",
                    StartDate = Convert.ToDateTime("1/5/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("8/20/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 59
                },
                new Project()
                {
                    Title = "Keylex",
                    CustomerCompany = "Leffler Inc",
                    PerformerCompany = "Davis, Frami and Haley",
                    StartDate = Convert.ToDateTime("5/21/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("10/17/2019", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 77
                },
                new Project()
                {
                    Title = "Fintone",
                    CustomerCompany = "Turcotte-Cole",
                    PerformerCompany = "Miller Group",
                    StartDate = Convert.ToDateTime("9/14/2017", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("2/23/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 39
                },
                new Project()
                {
                    Title = "Redhold",
                    CustomerCompany = "Goodwin-Conn",
                    PerformerCompany = "Roberts, Brown and Emard",
                    StartDate = Convert.ToDateTime("1/20/2018", new CultureInfo("en-US", false).DateTimeFormat),
                    EndDate = Convert.ToDateTime("6/14/2020", new CultureInfo("en-US", false).DateTimeFormat),
                    Priority = 3
                }
            };

            var employees = EmployeeConfiguration.Entities;
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Id = Guid.NewGuid();
                Entities[i].ManagerId = employees[1 + (i % (employees.Count - 1))].Id;
            }
        }

        #endregion
    }
}
