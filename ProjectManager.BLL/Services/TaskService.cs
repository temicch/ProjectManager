using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public class TaskService : ITaskService
    {
        public TaskService(IMapper mapper, BaseRepository<ProjectTask> repository)
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(repository));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private IMapper Mapper { get; }
        private BaseRepository<ProjectTask> Repository { get; }

        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskViewModel data)
        {
            if (!IsHavePermissionForEdit(user))
                return 0;

            ProjectTask task = Mapper.Map<ProjectTask>(data);

            await Repository.AddAsync(task);

            return task.Id;
        }

        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectTaskViewModel task)
        {
            if (!IsHavePermissionForEdit(user))
                return 0;

            return await Repository.UpdateAsync(Mapper.Map<ProjectTask>(task));
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            return Mapper.Map<IEnumerable<ProjectTaskViewModel>>(await Repository
                .GetAll()
                .ToListAsync());
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetOfEmployeeIdAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            return Mapper.Map<IEnumerable<ProjectTaskViewModel>>(await Repository
                .GetAll()
                .Where(x => x.Performer.Id == employeeId)
                .ToListAsync());
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id)
        {
            if (!IsHavePermissionForEdit(user))
                return false;

            return await Repository.RemoveByIdAsync(id);
        }

        public async Task<ProjectTaskViewModel> GetAsync(ClaimsPrincipal user, int id)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var task = await Repository.GetAsync(id);
            return task == null ? null : Mapper.Map<ProjectTaskViewModel>(task);
        }

        public async Task<bool> SetStatus(ClaimsPrincipal user, int id, DAL.Entities.TaskStatus taskStatus)
        {
            if (!IsHavePermissionForLook(user))
                return false;

            var task = await Repository.GetAsync(id);

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