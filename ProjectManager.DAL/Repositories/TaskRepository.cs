using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System.Linq;

namespace ProjectManager.DAL.Repositories
{
    public class TaskRepository : BaseRepository<ProjectTask>
    {
        public TaskRepository(ProjectDbContext projectDbContext) :
            base(projectDbContext, projectDbContext.Tasks)
        {
        }

        protected override IQueryable<ProjectTask> GetAllAsQuery()
        {
            return DbSet
                .Include(x => x.Author)
                .Include(x => x.Performer)
                .Include(x => x.Project);
        }
    }
}