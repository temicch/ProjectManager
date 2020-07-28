using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public class ProjectManager : IProjectManager
    {
        private IMapper Mapper { get; }
        private BaseRepository<Project> Repository { get; }
        private UserManager<Employee> UserManager { get; }

        public ProjectManager(IMapper mapper, 
            BaseRepository<Project> repository, 
            UserManager<Employee> userManager)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            UserManager = userManager;
        }
        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectViewModel data)
        {
            Project project = Mapper.Map<Project>(data);

            //var userId = user.GetLoggedInUserId<int>();
            //var user = 

            //project.Manager.Id = user.GetLoggedInUserId<int>();

            //await Repository.Projects.AddAsync(project);
            //await Repository.SaveChangesAsync();

            await Repository.AddAsync(project);

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ProjectViewModel project)
        {
            //Repository.Projects.Update(Mapper.Map<Project>(project));
            //await Repository.SaveChangesAsync();

            await Repository.UpdateAsync(Mapper.Map<Project>(project));

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public IEnumerable<ProjectViewModel> GetAll()
        {
            return Repository
                .GetAll()
                .Select(x => Mapper.Map<ProjectViewModel>(x));
        }

        public IEnumerable<ProjectViewModel> GetByEmployee(int employeeId)
        {
            //return Repository.ProjectEmployees
            //    .Include(x => x.Employee)
            //    .Include(x => x.Project)
            //    .Where(x => x.Employee.Id == employeeId)
            //    .Select(x => Mapper.Map<ProjectViewModel>(x));

            var projects = Repository.ProjectDbContext.ProjectEmployees
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .Where(x => x.Employee.Id == employeeId)
                .Select(x => Mapper.Map<ProjectViewModel>(x));
            return projects == null ? null : projects;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<bool> Remove(int id)
        {
            //Repository.Projects
            //    .Remove(Repository.Projects
            //        .Where(x => x.Id == id)
            //        .FirstOrDefault()
            //    );
            //await Repository.SaveChangesAsync();
            await Repository.RemoveAsync(id);
            return true;
        }

        public async Task<ProjectViewModel> Get(int id)
        {
            //    await Repository.Projects.LoadAsync();
            //    var project = await Repository.Projects.FindAsync(id);
            //    return project == null ? null : Mapper.Map<ProjectViewModel>(project);
            var project = await Repository.GetAsync(id);
            return project == null ? null : Mapper.Map<ProjectViewModel>(project);
        }
    }
}
