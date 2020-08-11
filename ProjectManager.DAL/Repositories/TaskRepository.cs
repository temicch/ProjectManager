using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Repositories
{
    public class TaskRepository : BaseRepository<ProjectTask>
    {
        public TaskRepository(ProjectDbContext projectDbContext, ILogger<TaskRepository> logger) :
            base(projectDbContext, projectDbContext.Tasks, logger)
        {
        }
    }
}