﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;
using System.Linq;

namespace ProjectManager.DAL.Repositories
{
    public class TaskRepository : BaseRepository<ProjectTask>
    {
        public TaskRepository(ProjectDbContext projectDbContext, ILogger logger) :
            base(projectDbContext, projectDbContext.Tasks, logger)
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