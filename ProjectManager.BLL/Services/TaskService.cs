﻿using AutoMapper;
using ProjectManager.BLL.Extensions;
using ProjectManager.BLL.Models;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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

        public async Task<Guid> CreateAsync(ClaimsPrincipal user, ProjectTaskModel project)
        {
            if (!user.CanCreateTask(project))
                return default;

            var task = Mapper.Map<ProjectTask>(project);

            await Repository.AddAsync(task);
            await Repository.SaveChangesAsync();

            return task.Id;
        }

        public async Task<Guid> EditAsync(ClaimsPrincipal user, ProjectTaskModel task)
        {
            if (!user.CanEditTask(task))
                return default;

            var entities = await Repository.GetByIdAsync(task.Id);
            var entityToUpdate = entities.First();
            Mapper.Map(task, entityToUpdate);

            var result = Repository.Update(entityToUpdate);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!user.CanLookAllTasks())
                return null;

            var tasks = await Repository.GetAllAsync();

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetOfEmployeeAsync(ClaimsPrincipal user, Guid employeeId)
        {
            if (!user.CanLookTask())
                return null;

            var tasks = await Repository.GetAsync(x => x.PerformerId == employeeId);

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, Guid taskId)
        {
            var task = Mapper.Map<ProjectTaskModel>((await Repository
                .GetByIdAsync(taskId))
                .FirstOrDefault());

            if (!user.CanRemoveTask(task))
                return false;

            var result = await Repository.RemoveByIdAsync(taskId);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<ProjectTaskModel> GetAsync(ClaimsPrincipal user, Guid Id)
        {
            if (!user.CanLookTask())
                return null;

            var task = await Repository.GetByIdAsync(Id);

            return Mapper.Map<ProjectTaskModel>(task.FirstOrDefault());
        }

        public async Task<bool> SetStatus(ClaimsPrincipal user, Guid taskId, TaskStatus taskStatus)
        {
            var task = (await Repository
                .GetByIdAsync(taskId))
                .FirstOrDefault();

            if (!user.CanChangeTaskStatus(Mapper.Map<ProjectTaskModel>(task)))
                return false;

            task.Status = taskStatus;

            var result = default(Guid).CompareTo(Repository.Update(task)) != 0;
            await Repository.SaveChangesAsync();

            return result;
        }
    }
}