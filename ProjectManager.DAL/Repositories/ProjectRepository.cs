using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(ProjectDbContext projectDbContext, ILogger<ProjectRepository> logger) :
            base(projectDbContext, projectDbContext.Projects, logger)
        {
        }

        protected override IQueryable<Project> GetAllAsQuery()
        {
            return DbSet
                .Include(x => x.Manager)
                .Include(x => x.Tasks);
        }
    }
}