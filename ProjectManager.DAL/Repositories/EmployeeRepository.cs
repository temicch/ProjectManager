using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;
using System.Linq;

namespace ProjectManager.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(ProjectDbContext projectDbContext, 
            ILogger logger) :
            base(projectDbContext, projectDbContext.Employees, logger)
        {
        }

        protected override IQueryable<Employee> GetAllAsQuery()
        {
            return DbSet
                .Include(x => x.Tasks)
                .Include(x => x.ManagedProjects)
                .Include(x => x.TasksAuthor);
        }
    }
}