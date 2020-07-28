using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.Utils;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
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
        private ProjectDbContext DBContext { get; }
        private UserManager<Employee> UserManager { get; }

        public ProjectManager(IMapper mapper, 
            ProjectDbContext dbContext, 
            UserManager<Employee> userManager)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(dbContext));
            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
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

            await DBContext.Projects.AddAsync(project);
            await DBContext.SaveChangesAsync();

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ProjectViewModel project)
        {
            DBContext.Projects.Update(Mapper.Map<Project>(project));
            await DBContext.SaveChangesAsync();

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            await DBContext.Projects.LoadAsync();

            var list = DBContext.Projects.ToList();
            //var employees = DBContext.Employees.ToList();

            //list[0].Manager = UserManager.FindByIdAsync(1.ToString()).Result;

            return DBContext.Projects
                //.Include(x => x.Manager)
                .Select(x => Mapper.Map<ProjectViewModel>(x));
        }

        public async Task<IEnumerable<ProjectViewModel>> GetByEmployee(int employeeId)
        {
            await DBContext.Projects.LoadAsync();
            return DBContext.ProjectEmployees
                .Where(x => x.EmployeeId == employeeId)
                .Select(x => Mapper.Map<ProjectViewModel>(x));
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<bool> Remove(int id)
        {
            DBContext.Projects
                .Remove(DBContext.Projects
                    .Where(x => x.Id == id)
                    .FirstOrDefault()
                );
            await DBContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectViewModel> Get(int id)
        {
            await DBContext.Projects.LoadAsync();
            var project = await DBContext.Projects.FindAsync(id);
            return project == null ? null : Mapper.Map<ProjectViewModel>(project);
        }
    }
}
