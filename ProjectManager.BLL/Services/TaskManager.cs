using Microsoft.AspNetCore.Authorization;
using ProjectManager.BLL.Utils;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace ProjectManager.BLL.Services
{
    public class TaskManager : ITaskManager
    {
        private ProjectDbContext DBContext { get; }

        public TaskManager(ProjectDbContext dbContext)
        {
            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async System.Threading.Tasks.Task<int> CreateAsync(ClaimsPrincipal user, TaskViewModel data)
        {
            Task task = (Task)(ITask)data;

            task.Author.Id = user.GetLoggedInUserId<int>();

            await DBContext.Tasks.AddAsync(task);
            await DBContext.SaveChangesAsync();

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async System.Threading.Tasks.Task<int> EditAsync(TaskViewModel task)
        {
            DBContext.Tasks.Update((Task)(ITask)task);
            await DBContext.SaveChangesAsync();

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public IEnumerable<TaskViewModel> GetAll()
        {
            return DBContext.Tasks.Select(x => new TaskViewModel(x));
        }

        public IEnumerable<TaskViewModel> GetByEmployee(int employeeId)
        {
            return DBContext.Tasks.Where(x => x.Performer.Id == employeeId).Select(x => new TaskViewModel(x));
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async System.Threading.Tasks.Task<bool> Remove(int id)
        {
            DBContext.Tasks.Remove(DBContext.Tasks.Where(x => x.Id == id).FirstOrDefault());
            await DBContext.SaveChangesAsync();
            return true;
        }

        public async System.Threading.Tasks.Task<TaskViewModel> Get(int id)
        {
            return new TaskViewModel(await DBContext.Tasks.FindAsync(id));
        }
    }
}
