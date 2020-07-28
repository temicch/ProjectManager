using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System.Linq;

namespace ProjectManager.DAL.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(ProjectDbContext projectDbContext):
            base(projectDbContext, projectDbContext.Projects)
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