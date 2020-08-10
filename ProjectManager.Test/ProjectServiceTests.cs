using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Moq;
using ProjectManager.BLL.Services;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using ProjectManager.Tests.DAL;
using Xunit;

namespace ProjectManager.Test
{
    public class ProjectServiceTests : IClassFixture<InitFixture>
    {
        public ProjectServiceTests(InitFixture initFixture)
        {
            DBFixture = initFixture;
        }

        private InitFixture DBFixture { get; }
        private BaseRepository<Project> Repository => DBFixture.Repository;
        private IList<Project> Projects => DBFixture.Projects;
        private ProjectService ProjectService => DBFixture.ProjectService;
        private Mock<ClaimsPrincipal> ClaimsPrincipal => DBFixture.ClaimsPrincipal;

        [Fact]
        public void Get_Should_Return_Empty_Collection()
        {
            Assert.Empty(Repository.GetByIdAsync(-1).Result);
        }

        [Fact]
        public void Get_Should_Return_Value()
        {
            for (var i = 0; i < Projects.Count; i++) 
                Assert.NotEmpty(Repository.GetByIdAsync(i + 1).Result);
        }


        [Fact]
        public async void GetAll_Should_Be_Equal_To_Projects_Count()
        {
            var repo = await Repository.GetAllAsync();
            
            Assert.Equal(Projects.Count, repo.Count());
        }

        [Fact]
        public void Remove_All_Entities_Must_Return_Empty_Collection()
        {
            var entities = ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result;

            foreach (var entity in entities)
            {
                var result = ProjectService.RemoveByIdAsync(ClaimsPrincipal.Object, entity.Id);
                Assert.True(result.Result);
            }

            entities = ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result;
            Assert.Empty(entities);
        }

        [Fact]
        public void Service_Should_Return_All_Entities()
        {
            Assert.Equal(ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result.Count(), Projects.Count());
        }

        [Fact]
        public void Should_Edit_Entity()
        {
            var entities = ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result;

            foreach (var entity in entities)
            {
                entity.Priority = 50000;
                var result = ProjectService.EditAsync(ClaimsPrincipal.Object, entity).Result;
                Assert.NotEqual(0, result);
            }

            entities = ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result;
            foreach (var entity in entities) Assert.Equal(50000d, entity.Priority);
        }

        [Fact]
        public void Shouldnt_Remove_Unknown_Entity()
        {
            Assert.False(ProjectService.RemoveByIdAsync(ClaimsPrincipal.Object, 0).Result);
        }
    }
}