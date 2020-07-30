using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ProjectManager.BLL.Services;
using ProjectManager.Configuration;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;

namespace ProjectManager.Tests.DAL
{
    public class InitFixture : IDisposable
    {
        public InitFixture()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase("ProjectDB")
                .Options;

            ProjectDbContext = new ProjectDbContext(options);
            Repository = new ProjectRepository(ProjectDbContext, new Mock<ILogger<ProjectRepository>>().Object);
            var PeRepository = new ProjectEmployeesRepository(ProjectDbContext,
                new Mock<ILogger<ProjectEmployeesRepository>>().Object);

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
        public Mock<ClaimsPrincipal> ClaimsPrincipal { get; set; }

        public void Dispose()
        {
        }

        private void InitClaims()
        {
            ClaimsPrincipal = new Mock<ClaimsPrincipal>();

            ClaimsPrincipal.Setup(x => x.IsInRole(It.IsAny<string>()))
                .Returns(true);

            var identityMock = new Mock<ClaimsIdentity>();
            identityMock.Setup(x => x.IsAuthenticated).Returns(true);
            ClaimsPrincipal.Setup(m => m.Identity).Returns(identityMock.Object);
        }

        private static IMapper InitMapper()
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
        }
    }
}