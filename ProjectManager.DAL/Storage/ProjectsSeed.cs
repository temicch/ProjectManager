using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Seeds
{
    internal static class ProjectsSeed
    {
        public static ICollection<Project> Projects;
        static ProjectsSeed()
        {
            Projects = new List<Project>
            {
                new Project()
                {
                    Id = new Guid("a2f60c6d-8cf7-4bf1-a5b3-293f4c5f113f"),
                    Title = "Cookley",
                    CustomerCompany = "Raynor Group",
                    PerformerCompany = "Schroeder LLC",
                    StartDate = Convert.ToDateTime("2/20/2018"),
                    EndDate = Convert.ToDateTime("1/12/2020"),
                    Priority = 29
                },
                new Project()
                {
                    Id = new Guid("3c791e6b-f4d9-4c36-b45a-a8ec343f4271"),
                    Title = "Kanlam",
                    CustomerCompany = "Morar Inc",
                    PerformerCompany = "Murphy, Emmerich and Muller",
                    StartDate = Convert.ToDateTime("3/8/2018"),
                    EndDate = Convert.ToDateTime("7/16/2020"),
                    Priority = 51
                },
                new Project()
                {
                    Id = new Guid("6ab6ae88-2139-437a-8fc2-c7760520f9d4"),
                    Title = "Transcof",
                    CustomerCompany = "Bosco, Zulauf and Lueilwitz",
                    PerformerCompany = "Terry-Doyle",
                    StartDate = Convert.ToDateTime("1/3/2018"),
                    EndDate = Convert.ToDateTime("7/23/2020"),
                    Priority = 7
                },
                new Project()
                {
                    Id = new Guid("b633f2ee-d3be-4b24-b207-83f28ad3bc98"),
                    Title = "Sonair",
                    CustomerCompany = "Bernhard-Mann",
                    PerformerCompany = "Rippin, Koch and Schowalter",
                    StartDate = Convert.ToDateTime("1/30/2018"),
                    EndDate = Convert.ToDateTime("10/9/2019"),
                    Priority = 99
                },
                new Project()
                {
                    Id = new Guid("0b5d380a-8b2a-4f12-bb57-a42ca110a397"),
                    Title = "Keylex",
                    CustomerCompany = "Stroman Group",
                    PerformerCompany = "Mayer, Klocko and McKenzie",
                    StartDate = Convert.ToDateTime("7/18/2018"),
                    EndDate = Convert.ToDateTime("2/27/2020"),
                    Priority = 99
                },
                new Project()
                {
                    Id = new Guid("650448e5-a6e8-4b41-badb-681f6414302c"),
                    Title = "Tin",
                    CustomerCompany = "Runolfsdottir-Kassulke",
                    PerformerCompany = "SchneIder, Kreiger and Kling",
                    StartDate = Convert.ToDateTime("1/24/2018"),
                    EndDate = Convert.ToDateTime("8/11/2020"),
                    Priority = 22
                },
                new Project()
                {
                    Id = new Guid("887c4022-b512-4958-8c77-f2b5172880a8"),
                    Title = "Sonair",
                    CustomerCompany = "Weimann, Purdy and Kessler",
                    PerformerCompany = "Rodriguez-Gorczany",
                    StartDate = Convert.ToDateTime("5/3/2018"),
                    EndDate = Convert.ToDateTime("3/15/2020"),
                    Priority = 6
                },
                new Project()
                {
                    Id = new Guid("26d28d03-33bc-44a6-b853-59afd86725d7"),
                    Title = "Andalax",
                    CustomerCompany = "Moen, Lesch and Dooley",
                    PerformerCompany = "Klocko Group",
                    StartDate = Convert.ToDateTime("9/12/2017"),
                    EndDate = Convert.ToDateTime("10/21/2019"),
                    Priority = 71
                },
                new Project()
                {
                    Id = new Guid("7b06fa22-bfab-4276-a3c1-9728426670af"),
                    Title = "Tampflex",
                    CustomerCompany = "Hessel-Feil",
                    PerformerCompany = "Blick, Bartoletti and Treutel",
                    StartDate = Convert.ToDateTime("9/14/2017"),
                    EndDate = Convert.ToDateTime("9/25/2019"),
                    Priority = 58
                },
                new Project()
                {
                    Id = new Guid("e8d8cde4-a6bd-41e2-ab2d-509521e89078"),
                    Title = "Otcom",
                    CustomerCompany = "Leffler, Dicki and Wisoky",
                    PerformerCompany = "Tillman, McGlynn and Gislason",
                    StartDate = Convert.ToDateTime("9/1/2017"),
                    EndDate = Convert.ToDateTime("5/30/2020"),
                    Priority = 31
                },
                new Project()
                {
                    Id = new Guid("86a99270-d04c-4616-ac12-ddc52765b029"),
                    Title = "Cookley",
                    CustomerCompany = "Walsh Inc",
                    PerformerCompany = "Mann, Gleason and Terry",
                    StartDate = Convert.ToDateTime("11/19/2017"),
                    EndDate = Convert.ToDateTime("2/16/2020"),
                    Priority = 24
                },
                new Project()
                {
                    Id = new Guid("0a768023-b4ab-48db-9636-a0c0a1c05902"),
                    Title = "Quo Lux",
                    CustomerCompany = "Bashirian, Windler and Sipes",
                    PerformerCompany = "Bergnaum-Rowe",
                    StartDate = Convert.ToDateTime("8/12/2018"),
                    EndDate = Convert.ToDateTime("4/1/2020"),
                    Priority = 65
                },
                new Project()
                {
                    Id = new Guid("15638a2c-c875-44f6-9261-cfaeb33d3911"),
                    Title = "Hatity",
                    CustomerCompany = "Mosciski LLC",
                    PerformerCompany = "Runolfsson-Zemlak",
                    StartDate = Convert.ToDateTime("1/14/2018"),
                    EndDate = Convert.ToDateTime("6/8/2020"),
                    Priority = 27
                },
                new Project()
                {
                    Id = new Guid("b7dd95d4-8ed5-4126-aa1e-b02ca22cdea6"),
                    Title = "Tin",
                    CustomerCompany = "Bashirian, Volkman and Becker",
                    PerformerCompany = "Shanahan, SchmIdt and Thiel",
                    StartDate = Convert.ToDateTime("10/25/2017"),
                    EndDate = Convert.ToDateTime("9/24/2019"),
                    Priority = 40
                },
                new Project()
                {
                    Id = new Guid("c5030a9c-6c76-4790-9bef-277350ffd6ff"),
                    Title = "Namfix",
                    CustomerCompany = "Zboncak-Block",
                    PerformerCompany = "Stracke-White",
                    StartDate = Convert.ToDateTime("4/27/2018"),
                    EndDate = Convert.ToDateTime("11/8/2019"),
                    Priority = 88
                },
                new Project()
                {
                    Id = new Guid("02251f34-cd57-45b7-8fd0-a58cea183b73"),
                    Title = "Job",
                    CustomerCompany = "Moen, Willms and Wuckert",
                    PerformerCompany = "Boehm, Morissette and Zulauf",
                    StartDate = Convert.ToDateTime("11/14/2017"),
                    EndDate = Convert.ToDateTime("9/13/2019"),
                    Priority = 20
                },
                new Project()
                {
                    Id = new Guid("412bccb1-11b9-48cf-9c5a-d26e5969c4ba"),
                    Title = "Tempsoft",
                    CustomerCompany = "Powlowski-Thompson",
                    PerformerCompany = "Klein LLC",
                    StartDate = Convert.ToDateTime("1/25/2018"),
                    EndDate = Convert.ToDateTime("11/15/2019"),
                    Priority = 3
                },
                new Project()
                {
                    Id = new Guid("4c621ed3-7d6e-4451-9c12-5d08637da4fc"),
                    Title = "Zamit",
                    CustomerCompany = "Pfeffer, Goyette and Spinka",
                    PerformerCompany = "Mayert, Mante and Dietrich",
                    StartDate = Convert.ToDateTime("1/5/2018"),
                    EndDate = Convert.ToDateTime("8/20/2019"),
                    Priority = 59
                },
                new Project()
                {
                    Id = new Guid("e818c382-9d06-4a86-bdc4-4552c06ca017"),
                    Title = "Keylex",
                    CustomerCompany = "Leffler Inc",
                    PerformerCompany = "Davis, Frami and Haley",
                    StartDate = Convert.ToDateTime("5/21/2018"),
                    EndDate = Convert.ToDateTime("10/17/2019"),
                    Priority = 77
                },
                new Project()
                {
                    Id = new Guid("feb13d42-8822-4c28-83a3-6f275e943db9"),
                    Title = "Fintone",
                    CustomerCompany = "Turcotte-Cole",
                    PerformerCompany = "Miller Group",
                    StartDate = Convert.ToDateTime("9/14/2017"),
                    EndDate = Convert.ToDateTime("2/23/2020"),
                    Priority = 39
                },
                new Project()
                {
                    Id = new Guid("58b2ee8b-0f91-4c5e-a908-e03db8e2c46f"),
                    Title = "Redhold",
                    CustomerCompany = "Goodwin-Conn",
                    PerformerCompany = "Roberts, Brown and Emard",
                    StartDate = Convert.ToDateTime("1/20/2018"),
                    EndDate = Convert.ToDateTime("6/14/2020"),
                    Priority = 3
                }
            };
        }
    }
}
