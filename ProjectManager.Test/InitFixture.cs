using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProjectManager.BLL;
using ProjectManager.BLL.Services;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using ProjectManager.PL.Configuration;

namespace ProjectManager.Tests.BLL
{
    public class InitFixture : IDisposable
    {
        public InitFixture()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase("ProjectDB")
                .Options;

            ProjectDbContext = new ProjectDbContext(options);

            Repository = new BaseRepository<Project>(ProjectDbContext, new Mock<ILogger<BaseRepository<Project>>>().Object);

            var PeRepository = new BaseRepository<ProjectEmployees>(ProjectDbContext,
                new Mock<ILogger<BaseRepository<ProjectEmployees>>>().Object);

            InitEmployees();

            _ = InitProjects();

            ProjectService = new ProjectService(InitMapper(), Repository, PeRepository);

            InitClaims();
        }

        public IList<Project> Projects { get; set; }
        public IList<Employee> Employees { get; set; }
        public ProjectDbContext ProjectDbContext { get; set; }
        public BaseRepository<Project> Repository { get; set; }
        public ProjectService ProjectService { get; set; }
        public ClaimsPrincipal UserLeader { get; set; }

        public void Dispose()
        {
            ProjectDbContext.Dispose();
        }

        private void InitClaims()
        {
            UserLeader = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "Example name"),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString(), nameof(Guid)),
                new Claim(ClaimTypes.Role, Roles.Leader),
            }, "mock"));
        }

        public static IMapper InitMapper()
        {
            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            IMapper mapper = new Mapper(configuration);
            return mapper;
        }

        private void InitEmployees()
        {
            Employees = new List<Employee>
            {
                new Employee("user1@email.com") {LastName = "Ильина", FirstName = "Смуйдра", Surname = "Кирилловна"},
                new Employee("user2@email.com") {LastName = "Баранов", FirstName = "Серафим", Surname = "Максимович"},
                new Employee("user3@email.com") {LastName = "Медведева", FirstName = "Адасия", Surname = "Алексеевна"},
                new Employee("user4@email.com") {LastName = "Данилов", FirstName = "Прохор", Surname = "Георгиевич"}
            };
        }

        private async Task InitProjects()
        {
            Projects = new List<Project>
            {
                new Project
                {
                    Title = "Money Pen",
                    StartDate = DateTime.Now.AddYears(-2),
                    EndDate = DateTime.Now.AddYears(-1),
                    PerformerCompany = "Sibers",
                    CustomerCompany = "Australian Company",
                    Priority = 4,
                    Manager = Employees[0]
                },
                new Project
                {
                    Title = "Voice Base",
                    StartDate = DateTime.Now.AddYears(-7),
                    EndDate = DateTime.Now,
                    PerformerCompany = "Sibers",
                    CustomerCompany = "Voice Analytic Company",
                    Priority = 12,
                    Manager = Employees[1]
                },
                new Project
                {
                    Title = "Multifunctional notebook for IPAD",
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now.AddYears(-2),
                    PerformerCompany = "Sibers",
                    CustomerCompany = "Sibers",
                    Priority = 1,
                    Manager = Employees[2]
                }
            };
            foreach (var project in Projects)
                await Repository.AddAsync(project);
            await Repository.SaveChangesAsync();
        }
    }
}