using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Repositories
{
    /// <summary>
    ///     Repository of (Project - Employees) relations
    /// </summary>
    public class ProjectEmployeesRepository : BaseRepository<ProjectEmployees>
    {
        public ProjectEmployeesRepository(ProjectDbContext projectDbContext,
            ILogger<ProjectEmployeesRepository> logger) :
            base(projectDbContext, projectDbContext.ProjectEmployees, logger)
        {
        }

        protected override IQueryable<ProjectEmployees> GetAllAsQuery()
        {
            return DbSet
                .Include(x => x.Employee)
                .Include(x => x.Project);
        }
    }
}