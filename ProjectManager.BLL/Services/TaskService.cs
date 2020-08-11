using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using ProjectManager.BLL.Extensions;
using ProjectManager.BLL.Models;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using TaskStatus = ProjectManager.DAL.Entities.TaskStatus;

namespace ProjectManager.BLL.Services
{
    public class TaskService : ITaskService
    {
        public TaskService(IMapper mapper, 
            BaseRepository<ProjectTask> repository)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private IMapper Mapper { get; }
        private BaseRepository<ProjectTask> Repository { get; }

        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskModel project)
        {
            if (!user.CanCreateTask(project))
                return 0;

            var task = Mapper.Map<ProjectTask>(project);

            await Repository.AddAsync(task);

            return task.Id;
        }

        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectTaskModel task)
        {
            if (!user.CanEditTask(task))
                return 0;

            return await Repository.UpdateAsync(Mapper.Map<ProjectTask>(task));
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!user.CanLookAllTasks())
                return null;

            var tasks = await Repository.GetAllAsync();

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetOfEmployeeAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!user.CanLookTask())
                return null;

            var tasks = await Repository.GetAsync(x => x.PerformerId == employeeId);

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int taskId)
        {
            var task = Mapper.Map<ProjectTaskModel>((await Repository
                .GetByIdAsync(taskId))
                .FirstOrDefault());

            if (!user.CanRemoveTask(task))
                return false;

            return await Repository.RemoveByIdAsync(taskId);
        }

        public async Task<ProjectTaskModel> GetAsync(ClaimsPrincipal user, int id)
        {
            if (!user.CanLookTask())
                return null;

            var task = await Repository.GetByIdAsync(id);

            return Mapper.Map<ProjectTaskModel>(task.FirstOrDefault());
        }

        public async Task<bool> SetStatus(ClaimsPrincipal user, int taskId, TaskStatus taskStatus)
        {
            var task = (await Repository
                .GetByIdAsync(taskId))
                .FirstOrDefault();

            if (!user.CanChangeTaskStatus(Mapper.Map<ProjectTaskModel>(task)))
                return false;

            task.Status = taskStatus;

            return await Repository.UpdateAsync(task) != 0;
        }
    }
}