using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Storage
{
    internal static class TasksSeed
    {
        public static ICollection<ProjectTask> Tasks { get; set; }
        static TasksSeed()
        {
            Tasks = new List<ProjectTask>
            {
                new ProjectTask(){
                    Id = Guid.Parse("af21ef94-b92f-4c41-b638-2156dc8360d5"),
                    Title = "Down-sized local intranet",
                    Comment = 
                    "Pellentesque viverra pede ac diam. Cras pellentesque volutpat dui. Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.",
                    Priority = 28
                },
                new ProjectTask(){
                    Id = Guid.Parse("4461d589-6444-4706-bf66-b42910568d30"),
                    Title = "Open-source directional local area network",
                    Comment = 
                    "Nullam sit amet turpis elementum ligula vehicula consequat. Morbi a ipsum. Integer a nibh.",
                    Priority = 26
                },
                new ProjectTask(){
                    Id = Guid.Parse("89efd2f5-2800-4687-ae1d-b48040a4d5b7"),
                    Title = "Synergistic tertiary moderator",
                    Comment = 
                    "In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.",
                    Priority = 89
                },
                new ProjectTask(){
                    Id = Guid.Parse("6123d36e-f32b-487f-ba04-2e237e380ab5"),
                    Title = "Future-proofed impactful policy",
                    Comment = 
                    "In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem. Integer tincidunt ante vel ipsum.",
                    Priority = 7
                },
                new ProjectTask(){
                    Id = Guid.Parse("fecd2c00-b78b-403e-9437-7a3171fb8a9a"),
                    Title = "Total multimedia toolset",
                    Comment =  "Pellentesque viverra pede ac diam.",
                    Priority = 5
                },
                new ProjectTask(){
                    Id = Guid.Parse("3584228a-c7da-43d0-8f21-2a145dcc5eb7"),
                    Title = "Multi-tiered tangible task-force",
                    Comment = 
                    "Nullam orci pede, venenatis non, sodales sed, tincidunt eu, felis. Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl.",
                    Priority = 76
                },
                new ProjectTask(){
                    Id = Guid.Parse("aa4a5323-3075-436d-85c0-79f1eb6cf6b1"),
                    Title = "Robust homogeneous benchmark",
                    Comment =  "Donec dapibus.",
                    Priority = 28
                },
                new ProjectTask(){
                    Id = Guid.Parse("90a6b950-5f2f-47a0-852b-553e174461e4"),
                    Title = "Realigned high-level process improvement",
                    Comment = 
                    "Nulla facilisi. Cras non velit nec nisi vulputate nonummy. Maecenas tincidunt lacus at velit.",
                    Priority = 84
                },
                new ProjectTask(){
                    Id = Guid.Parse("10d79689-1fa1-44b6-8f3a-caab20a8d3b2"),
                    Title = "Centralized analyzing encryption",
                    Comment = 
                    "Fusce consequat. Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa.",
                    Priority = 22
                },
                new ProjectTask(){
                    Id = Guid.Parse("43ac22a1-8203-47c6-b6e1-3586b7664d4a"),
                    Title = "Customizable incremental model",
                    Comment =  "Nullam porttitor lacus at turpis.",
                    Priority = 60
                },
                new ProjectTask(){
                    Id = Guid.Parse("ff5ca4e2-0fa2-4bb3-b49c-242880e1c2d8"),
                    Title = "User-friendly zero administration process improvement",
                    Comment = 
                    "Suspendisse potenti. Nullam porttitor lacus at turpis. Donec posuere metus vitae ipsum. Aliquam non mauris.",
                    Priority = 96
                },
                new ProjectTask(){
                    Id = Guid.Parse("e8738542-16a0-4d8c-96f3-0534e0608975"),
                    Title = "Centralized grid-enabled task-force",
                    Comment =  "Morbi porttitor lorem id ligula. Suspendisse ornare consequat lectus.",
                    Priority = 60
                },
                new ProjectTask(){
                    Id = Guid.Parse("0086b1ee-614c-4b60-be77-293d334a07ac"),
                    Title = "Horizontal encompassing encoding",
                    Comment =  "Aenean lectus. Pellentesque eget nunc.",
                    Priority = 22
                },
                new ProjectTask(){
                    Id = Guid.Parse("28d650fd-4134-4534-96e6-45b37f5b0fb9"),
                    Title = "Monitored transitional capability",
                    Comment = 
                    "Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue.",
                    Priority = 79
                },
                new ProjectTask(){
                    Id = Guid.Parse("53ab616e-df72-4630-b3d1-f0777d3a111a"),
                    Title = "Advanced mobile productivity",
                    Comment =  "Morbi a ipsum. Integer a nibh. In quis justo. Maecenas rhoncus aliquam lacus.",
                    Priority = 12
                },
                new ProjectTask(){
                    Id = Guid.Parse("c7605ad4-d74c-487b-bfa8-4ea6bc41d930"),
                    Title = "Seamless 4th generation capacity",
                    Comment = 
                    "Quisque ut erat. Curabitur gravida nisi at nibh. In hac habitasse platea dictumst. Aliquam augue quam, sollicitudin vitae, consectetuer eget, rutrum at, lorem.",
                    Priority = 25
                },
                new ProjectTask(){
                    Id = Guid.Parse("655c2699-a3c4-418a-852b-eaa392644b52"),
                    Title = "Down-sized upward-trending extranet",
                    Comment = 
                    "Suspendisse accumsan tortor quis turpis. Sed ante. Vivamus tortor. Duis mattis egestas metus.",
                    Priority = 18
                },
                new ProjectTask(){
                    Id = Guid.Parse("729043ae-79fb-4965-8cb6-e6a32337fc78"),
                    Title = "Horizontal bandwidth-monitored ability",
                    Comment = 
                    "Nulla nisl. Nunc nisl. Duis bibendum, felis sed interdum venenatis, turpis enim blandit mi, in porttitor pede justo eu massa. Donec dapibus.",
                    Priority = 4
                },
                new ProjectTask(){
                    Id = Guid.Parse("7199682b-35bd-4717-b281-494b864a62fb"),
                    Title = "Multi-tiered cohesive capacity",
                    Comment =  "Morbi ut odio. Cras mi pede, malesuada in, imperdiet et, commodo vulputate, justo.",
                    Priority = 80
                },
                new ProjectTask(){
                    Id = Guid.Parse("acfc5add-d0c2-46ad-8721-272e1d6709f7"),
                    Title = "Team-oriented mission-critical encryption",
                    Comment =  "Integer ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.",
                    Priority = 11
                },
                new ProjectTask(){
                    Id = Guid.Parse("4b89f71d-1ad4-4431-9733-842093f1cbce"),
                    Title = "Front-line object-oriented alliance",
                    Comment =  "Integer ac neque. Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.",
                    Priority = 6
                },
                new ProjectTask(){
                    Id = Guid.Parse("57cbd8dd-bc01-4752-8bd9-62946003376b"),
                    Title = "Cross-platform motivating system engine",
                    Comment =  "Morbi non quam nec dui luctus rutrum. Nulla tellus. In sagittis dui vel nisl.",
                    Priority = 68
                },
                new ProjectTask(){
                    Id = Guid.Parse("85e9b6d6-4af5-42a3-be1c-48c3626ef4ab"),
                    Title = "Fundamental eco-centric internet solution",
                    Comment = 
                    "Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Etiam vel augue. Vestibulum rutrum rutrum neque. Aenean auctor gravida sem.",
                    Priority = 81
                },
                new ProjectTask(){
                    Id = Guid.Parse("cf334562-257e-4ae3-b575-4e7e6cb61f71"),
                    Title = "Networked encompassing workforce",
                    Comment =  "Curabitur gravida nisi at nibh.",
                    Priority = 1
                },
                new ProjectTask(){
                    Id = Guid.Parse("8b336c93-111c-4628-8b90-33e57964073a"),
                    Title = "User-friendly transitional monitoring",
                    Comment =  "In sagittis dui vel nisl.",
                    Priority = 85
                },
                new ProjectTask(){
                    Id = Guid.Parse("ab1fac54-f8b4-4a39-bc6c-31729a091de7"),
                    Title = "Intuitive leading edge algorithm",
                    Comment =  "In hac habitasse platea dictumst. Maecenas ut massa quis augue luctus tincidunt.",
                    Priority = 65
                },
                new ProjectTask(){
                    Id = Guid.Parse("f65f52b5-590d-4db2-a613-c356bbf6ddc4"),
                    Title = "Seamless 24/7 array",
                    Comment =  "Nulla nisl.",
                    Priority = 81
                },
                new ProjectTask(){
                    Id = Guid.Parse("0e6d8a7c-dab2-481b-82f1-d8a24de98f9f"),
                    Title = "Down-sized bifurcated moderator",
                    Comment =  "Etiam pretium iaculis justo.",
                    Priority = 1
                },
                new ProjectTask(){
                    Id = Guid.Parse("d8c9b0ce-f3a8-49fb-8f77-c4172d3409cc"),
                    Title = "Persevering asynchronous extranet",
                    Comment =  "Nulla suscipit ligula in lacus.",
                    Priority = 99
                },
                new ProjectTask(){
                    Id = Guid.Parse("12336037-6ea0-4541-a418-c558c804ef12"),
                    Title = "Reverse-engineered full-range solution",
                    Comment = 
                    "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nulla dapibus dolor vel est. Donec odio justo, sollicitudin ut, suscipit a, feugiat et, eros. Vestibulum ac est lacinia nisi venenatis tristique. Fusce congue, diam id ornare imperdiet, sapien urna pretium nisl, ut volutpat sapien arcu sed augue.",
                    Priority = 61
                }
            };
            var values = Enum.GetValues(typeof(TaskStatus));
            Random random = new Random();
            foreach (var task in Tasks)
            {
                task.Status = (TaskStatus) values.GetValue(random.Next(values.Length));
            }
        }
    }
}
