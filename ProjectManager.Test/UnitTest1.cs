using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using System;
using Moq;
using Xunit;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;

namespace ProjectManager.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "ProjectDB")
                .Options;

            var user = new Mock<ClaimsPrincipal>();

            // Insert seed data into the database using one instance of the context
            using (var context = new ProjectDbContext(options))
            {
                var usersInfo = new[]
                {
                    new[] { "user1@email.com", "������", "�������", "����������" },
                    new[] { "user2@email.com", "�������", "�������", "����������" },
                    new[] { "user3@email.com", "���������", "������", "����������" },
                    new[] { "user4@email.com", "�������", "������", "����������" },
                };

                Employee[] users = new Employee[usersInfo.Length];

                int i = 0;
                foreach (var info in usersInfo)
                {
                    users[i++] = new Employee(info[0])
                    {
                        FirstName = info[1],
                        LastName = info[2],
                        Surname = info[3]
                    };
                }
                context.Projects.Add(new Project()
                {
                    Title = "Money Pen",
                    StartDate = DateTime.Now.AddYears(-2),
                    EndDate = DateTime.Now.AddYears(-1),
                    PerformerCompany = "Sibers",
                    CustomerCompany = "Australian Company",
                    Priority = 4,
                    Manager = users[0],
                });
                context.Projects.Add(new Project()
                {
                    Title = "Voice Base",
                    StartDate = DateTime.Now.AddYears(-7),
                    EndDate = DateTime.Now,
                    PerformerCompany = "Sibers",
                    CustomerCompany = "Voice Analytic Company",
                    Priority = 12,
                    Manager = users[1],
                });
                context.Projects.Add(new Project()
                {
                    Title = "Multifunctional notebook for IPAD",
                    StartDate = DateTime.Now.AddYears(-3),
                    EndDate = DateTime.Now.AddYears(-2),
                    PerformerCompany = "Sibers",
                    CustomerCompany = "Sibers",
                    Priority = 1,
                    Manager = users[2],
                });
                context.SaveChanges();
            }

            //// Use a clean instance of the context to run the test
            //using (var context = new ProjectDbContext(options))
            //{
            //    MovieRepository movieRepository = new MovieRepository(context);
            //    List<Movies> movies == movieRepository.GetAll()

            //Assert.Equal(3, movies.Count);
            //}




        }

        [Fact]
        public async Task RegisterNewUser_ReturnsHttpStatusOK_WhenValidModelPosted()
        {
            //Arrange
            var mockStore = Mock.Of<IUserStore<Employee>>();
            await mockStore.CreateAsync(new Mock<Employee>("user").Object, new System.Threading.CancellationToken());
            

            var mockUserManager = new Mock<UserManager<Employee>>(mockStore, null, null, null, null, null, null, null, null);

            mockUserManager
                .Setup(x => x.CreateAsync(It.IsAny<Employee>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            
            //Act
            //var actual = await sut.RegisterNewUser(input);

            //Assert
            //actual
            //    .Should().NotBeNull()
            //    .And.Match<HttpResponseMessage>(_ => _.IsSuccessStatusCode == true);
        }
    }
}