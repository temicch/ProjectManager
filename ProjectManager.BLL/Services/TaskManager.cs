using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.Utils;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public class TaskManager : ITaskManager
    {
        private IMapper Mapper { get; }
        private ProjectDbContext DBContext { get; }

        public TaskManager(IMapper mapper, ProjectDbContext dbContext)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(dbContext));
            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskViewModel data)
        {
            ProjectTask task = Mapper.Map<ProjectTask>(data);

            task.Author.Id = user.GetLoggedInUserId<int>();

            await DBContext.Tasks.AddAsync(task);
            await DBContext.SaveChangesAsync();

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ProjectTaskViewModel task)
        {
            DBContext.Tasks.Update(Mapper.Map<ProjectTask>(task));
            await DBContext.SaveChangesAsync();

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IEnumerable<ProjectTaskViewModel>> GetAll()
        {
            await DBContext.Tasks.LoadAsync();
            return DBContext.Tasks.Select(x => Mapper.Map<ProjectTaskViewModel>(x));
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetByEmployee(int employeeId)
        {
            await DBContext.Tasks.LoadAsync();
            return DBContext.Tasks.Where(x => x.Performer.Id == employeeId).Select(x => Mapper.Map<ProjectTaskViewModel>(x));
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<bool> Remove(int id)
        {
            DBContext.Tasks.Remove(DBContext.Tasks.Where(x => x.Id == id).FirstOrDefault());
            await DBContext.SaveChangesAsync();
            return true;
        }

        public async Task<ProjectTaskViewModel> Get(int id)
        {
            await DBContext.Tasks.LoadAsync();
            return Mapper.Map<ProjectTaskViewModel>(await DBContext.Tasks.FindAsync(id));
        }
    }
}
