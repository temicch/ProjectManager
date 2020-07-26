using Microsoft.AspNetCore.Authorization;
using ProjectManager.BLL.Utils;
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
            Project project = data;

            project.ManagerId = user.GetLoggedInUserId<string>();

            await DBContext.Projects.AddAsync(project);
            await DBContext.SaveChangesAsync();

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ProjectViewModel project)
        {
            DBContext.Projects.Update(project);
            await DBContext.SaveChangesAsync();

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public IEnumerable<IProject> GetAll()
        {
            return DBContext.Projects;
        }

        public IEnumerable<IProject> GetByEmployee(IEmployee employee)
        {
            return DBContext.Projects.Where(x => x.Performers.Contains(employee));
        }

        public bool Remove(IProject project)
        {
            DBContext.Projects.Remove(project as Project);
            return true;
        }
    }
}
