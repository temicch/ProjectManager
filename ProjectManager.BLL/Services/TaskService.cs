using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskModel data)
        {
            if (!IsHavePermissionForEdit(user))
                return 0;

            var task = Mapper.Map<ProjectTask>(data);

            await Repository.AddAsync(task);

            return task.Id;
        }

        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectTaskModel task)
        {
            if (!IsHavePermissionForEdit(user))
                return 0;

            return await Repository.UpdateAsync(Mapper.Map<ProjectTask>(task));
        }

        public IEnumerable<ProjectTaskModel> GetAll(ClaimsPrincipal user)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(Repository
                .GetAll()
                .ToList());
        }

        public IEnumerable<ProjectTaskModel> GetOfEmployee(ClaimsPrincipal user, int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(Repository
                .GetAll()
                .Where(x => x.Performer.Id == employeeId)
                .ToList());
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id)
        {
            if (!IsHavePermissionForEdit(user))
                return false;

            return await Repository.RemoveByIdAsync(id);
        }

        public async Task<ProjectTaskModel> GetAsync(ClaimsPrincipal user, int id)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var task = await Repository.GetByIdAsync(id);
            return task == null ? null : Mapper.Map<ProjectTaskModel>(task);
        }

        public async Task<bool> SetStatus(ClaimsPrincipal user, int id, TaskStatus taskStatus)
        {
            if (!IsHavePermissionForLook(user))
                return false;

            var task = (await Repository.GetByIdAsync(id)).FirstOrDefault();

            if (task == null)
                return false;

            task.Status = taskStatus;
            return await Repository.UpdateAsync(task) != 0;
        }

        private bool IsHavePermissionForEdit(ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader);
        }

        private bool IsHavePermissionForLook(ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }
    }
}