﻿using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;

namespace ProjectManager.DAL.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(ProjectDbContext projectDbContext,
            ILogger<EmployeeRepository> logger) :
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