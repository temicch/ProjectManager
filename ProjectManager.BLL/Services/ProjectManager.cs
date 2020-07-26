using Microsoft.AspNetCore.Authorization;
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
        private ProjectDbContext DBContext { get; }

        public ProjectManager(ProjectDbContext dbContext)
        {
            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectViewModel data)
        {
            Project project = (Project)(IProject)data;

            project.ManagerId = user.GetLoggedInUserId<string>();

            await DBContext.Projects.AddAsync(project);
            await DBContext.SaveChangesAsync();

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ProjectViewModel project)
        {
            DBContext.Projects.Update((Project)(IProject)project);
            await DBContext.SaveChangesAsync();

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public IEnumerable<ProjectViewModel> GetAll()
        {
            return DBContext.Projects
                .Select(x => new ProjectViewModel(x));
        }

        public IEnumerable<ProjectViewModel> GetByEmployee(string employeeId)
        {
            return DBContext.ProjectEmployees
                .Where(x => x.EmployeeId == employeeId)
                .Select(x => new ProjectViewModel());
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
            return new ProjectViewModel(await DBContext.Projects
                .FindAsync(id)
                );
        }
    }
}
