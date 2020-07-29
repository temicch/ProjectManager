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

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskViewModel data)
        {
            ProjectTask task = Mapper.Map<ProjectTask>(data);

            await Repository.AddAsync(task);

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectTaskViewModel task)
        {
            await Repository.UpdateAsync(Mapper.Map<ProjectTask>(task));

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IEnumerable<ProjectTaskViewModel>> GetAllAsync(ClaimsPrincipal user)
        {
            return Mapper.Map<IEnumerable<ProjectTaskViewModel>>(await Repository
                .GetAll()
                .ToListAsync());
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetAllByEmployeeAsync(ClaimsPrincipal user, int employeeId)
        {
            return Mapper.Map<IEnumerable<ProjectTaskViewModel>>(await Repository
                .GetAll()
                .Where(x => x.Performer.Id == employeeId)
                .ToListAsync());
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id)
        {
            var entity = await Repository.RemoveAsyncById(id);

            return entity;
        }

        public async Task<ProjectTaskViewModel> GetByIdAsync(ClaimsPrincipal user, int id)
        {
            var task = await Repository.GetAsync(id);
            return task == null ? null : Mapper.Map<ProjectTaskViewModel>(task);
        }
    }
}