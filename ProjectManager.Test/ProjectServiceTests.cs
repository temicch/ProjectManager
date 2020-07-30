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
using System.Threading;
using ProjectManager.DAL.Repositories;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ProjectManager.Tests.DAL;
using ProjectManager.BLL.Services;
using System.Security.Principal;

namespace ProjectManager.Test
{
    public class ProjectServiceTests: IClassFixture<InitFixture>
    {
        InitFixture DBFixture { get; set; }
        BaseRepository<Project> Repository => DBFixture.Repository;
        IList<Project> Projects => DBFixture.Projects;
        ProjectService ProjectService => DBFixture.ProjectService;
        Mock<ClaimsPrincipal> ClaimsPrincipal => DBFixture.ClaimsPrincipal;

        public ProjectServiceTests(InitFixture dbFixture)
        {
            DBFixture = dbFixture;
        }


        [Fact]
        public void GetAll_Should_Be_Projects_Count()
        {
            var repoCount = Repository.GetAll().Count();
            Assert.Equal(repoCount, Projects.Count);
        }

        [Fact]
        public void Get_Should_Return_Value()
        {
            for (int i = 0; i < Projects.Count; i++)
            {
                Assert.NotNull(Repository.GetAsync(i + 1).Result);
            }
        }

        [Fact]
        public void Get_Should_Return_Null()
        {
            Assert.Null(Repository.GetAsync(-1).Result);
        }

        [Fact]
        public void Service_Should_Return_All_Entities()
        {
            Assert.Equal(ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result.Count(), Projects.Count());
        }

        [Fact]
        public void Shouldnt_Remove_Unknown_Entity()
        {
            Assert.False(ProjectService.RemoveByIdAsync(ClaimsPrincipal.Object, 0).Result);
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
            foreach (var entity in entities)
            {
                Assert.Equal(50000d, entity.Priority);
            }
        }

        [Fact]
        public void Remove_All_Entities()
        {
            var entities = ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result;

            foreach (var entity in entities)
            {
                var result = ProjectService.RemoveByIdAsync(ClaimsPrincipal.Object, entity.Id);
                Assert.True(result.Result);
            }

            entities = ProjectService.GetAllAsync(ClaimsPrincipal.Object).Result;
            Assert.Equal(0, entities.Count());
        }
    }
}
