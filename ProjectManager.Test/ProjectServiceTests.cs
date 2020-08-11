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
        public async void Get_Should_Return_Empty_Collection()
        {
            var result = await Repository.GetByIdAsync(-1);

            Assert.Empty(result);
        }

        //[Fact]
        //public async void Get_Should_Return_Value()
        //{
        //    for (var i = 0; i < Projects.Count; i++)
        //    {
        //        var result = await Repository.GetByIdAsync(i + 1);
        //        Assert.NotEmpty(result);
        //    }
        //}


        //[Fact]
        //public async void GetAll_Should_Be_Equal_To_Projects_Count()
        //{
        //    var repo = await Repository.GetAllAsync();
            
        //    Assert.Equal(Projects.Count, repo.Count());
        //}

        [Fact]
        public async void Remove_All_Entities_Must_Return_Empty_Collection()
        {
            var entities = await ProjectService.GetAllAsync(ClaimsPrincipal.Object);

            foreach (var entity in entities)
            {
                var result = await ProjectService.RemoveByIdAsync(ClaimsPrincipal.Object, entity.Id);
                Assert.True(result);
            }

            entities = await ProjectService.GetAllAsync(ClaimsPrincipal.Object);

            Assert.Empty(entities);
        }

        //[Fact]
        //public async void Service_Should_Return_All_Entities()
        //{
        //    var entities = await ProjectService.GetAllAsync(ClaimsPrincipal.Object);

        //    Assert.Equal(Projects.Count(), entities.Count());
        //}

        [Fact]
        public async void Should_Edit_Entity()
        {
            var entities = await ProjectService.GetAllAsync(ClaimsPrincipal.Object);

            foreach (var entity in entities)
            {
                entity.Priority = 50000;
                var result = await ProjectService.EditAsync(ClaimsPrincipal.Object, entity);
                Assert.NotEqual(0, result);
            }

            entities = await ProjectService.GetAllAsync(ClaimsPrincipal.Object);

            foreach (var entity in entities) 
                Assert.Equal(50000d, entity.Priority);
        }

        [Fact]
        public async void Shouldnt_Remove_Unknown_Entity()
        {
            var result = await ProjectService.RemoveByIdAsync(ClaimsPrincipal.Object, 0);

            Assert.False(result);
        }
    }
}