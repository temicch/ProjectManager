using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public class TaskManager : ITaskManager
    {
        public TaskManager(IMapper mapper, BaseRepository<ProjectTask> repository)
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
        public async Task<int> EditAsync(ProjectTaskViewModel task)
        {
            await Repository.UpdateAsync(Mapper.Map<ProjectTask>(task));

            return task.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public IEnumerable<ProjectTaskViewModel> GetAll()
        {
            return Repository.GetAll().Select(x => Mapper.Map<ProjectTaskViewModel>(x));
        }

        public IEnumerable<ProjectTaskViewModel> GetByEmployee(int employeeId)
        {
            return Repository
                .GetAll()
                .Where(x => x.Performer.Id == employeeId)
                .Select(x => Mapper.Map<ProjectTaskViewModel>(x));
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<bool> Remove(int id)
        {
            await Repository.RemoveAsync(id);

            return true;
        }

        public async Task<ProjectTaskViewModel> Get(int id)
        {
            var task = await Repository.GetAsync(id);
            return task == null ? null : Mapper.Map<ProjectTaskViewModel>(task);
        }
    }
}