using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.DAL.Repositories
{
    public class ProjectEmployeesRepository : BaseRepository<ProjectEmployees>
    {
        public ProjectEmployeesRepository(ProjectDbContext projectDbContext) :
            base(projectDbContext, projectDbContext.ProjectEmployees)
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
