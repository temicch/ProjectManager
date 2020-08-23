using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ProjectManager.BLL.Services;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using Xunit;

namespace ProjectManager.Tests.BLL
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
        private ClaimsPrincipal ClaimsPrincipal => DBFixture.UserLeader;

        [Fact]
        public async void Get_Should_Return_Empty_Collection()
        {
            Assert.False(IsEmptyRepository());

            var result = await Repository.GetByIdAsync(Guid.Empty);

            Assert.Empty(result);
        }
        
        [Fact]
        public async void Correct_Remove_Entity()
        {
            Assert.False(IsEmptyRepository());

            var entities = await ProjectService.GetAllAsync(ClaimsPrincipal);

            var entityId = entities.First().Id;

            await ProjectService.RemoveByIdAsync(ClaimsPrincipal, entityId);
            await Repository.SaveChangesAsync();

            var serviceEntity = await ProjectService.GetAsync(ClaimsPrincipal, entityId);
            
            Assert.Null(serviceEntity);

            var repoEntity = await Repository.GetByIdAsync(entityId);

            Assert.Empty(repoEntity);
        }

        [Fact]
        public async void Should_Edit_Entity()
        {
            Assert.False(IsEmptyRepository());

            var entities = await ProjectService.GetAllAsync(ClaimsPrincipal);

            foreach (var entity in entities)
            {
                entity.Priority = 50000;

                var result = await ProjectService.EditAsync(ClaimsPrincipal, entity);
                Assert.NotEqual(Guid.Empty, result);
            }

            entities = await ProjectService.GetAllAsync(ClaimsPrincipal);

            foreach (var entity in entities) 
                Assert.Equal(50000d, entity.Priority);
        }

        [Fact]
        public async void Should_Not_Remove_Unknown_Entity()
        {
            var result = await ProjectService.RemoveByIdAsync(ClaimsPrincipal, Guid.Empty);

            Assert.False(result);
        }

        private bool IsEmptyRepository()
        {
            var entities = ProjectService.GetAllAsync(ClaimsPrincipal).Result;
            return !entities.Any();
        }
    }
}