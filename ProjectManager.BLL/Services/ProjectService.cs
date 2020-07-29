using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.Utils;
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
    public class ProjectService : IProjectService
    {
        public ProjectService(
            IMapper mapper,
            BaseRepository<Project> repository
            )
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        private IMapper Mapper { get; }
        private BaseRepository<Project> Repository { get; }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectViewModel data)
        {
            Project project = Mapper.Map<Project>(data);

            await Repository.AddAsync(project);

            return project.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectViewModel project)
        {
            await Repository.UpdateAsync(Mapper.Map<Project>(project));

            return project.Id;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllAsync(ClaimsPrincipal user)
        {
            var entities = await GetAllFilteredEntities(user).ToListAsync();
            return Mapper.Map<IEnumerable<ProjectViewModel>>(entities);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllByEmployeeAsync(ClaimsPrincipal user, int employeeId)
        {
            var projects = Mapper.Map<IEnumerable<ProjectViewModel>>(await Repository.ProjectDbContext.ProjectEmployees
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .Where(x => x.Employee.Id == employeeId)
                .ToListAsync());
            return projects;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int projectId)
        {
            var entityResult = await Repository.RemoveAsyncById(projectId);
            return entityResult;
        }

        public async Task<ProjectViewModel> GetByIdAsync(ClaimsPrincipal user, int projectId)
        {
            var project = await Repository.GetAsync(projectId);
            return project == null ? null : Mapper.Map<ProjectViewModel>(project);
        }

        public async Task<bool> AddEmployeeAsync(ClaimsPrincipal user, int projectId, int employeeId)
        {
            var entity = await Repository.ProjectDbContext.ProjectEmployees
                .AddAsync(new ProjectEmployees() { EmployeeId = employeeId, ProjectId = projectId });
            return entity.IsKeySet;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync(ClaimsPrincipal user, int projectId)
        {
            var employees = Mapper.Map<IEnumerable<EmployeeViewModel>>(await Repository.ProjectDbContext.ProjectEmployees
                .Where(x => x.ProjectId == projectId)
                .ToListAsync());
            return employees;
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetTasksAsync(ClaimsPrincipal user, int projectId)
        {
            var tasks = Mapper.Map<IEnumerable<ProjectTaskViewModel>>(await Repository
                .GetAll()
                .Where(x => x.Id == projectId)
                .Select(x => x.Tasks)
                .ToListAsync());
            return tasks;
        }
        private IQueryable<Project> GetAllFilteredEntities(ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            var entities = Repository.GetAll();
            var userId = user.GetLoggedInUserId<int>();
            // Leader can view any projects, so nothing filter to
            if (user.IsInRole(Roles.Leader))
            {
            }
            // Other roles can see only theirs projects. Filter it
            else if (user.IsInRole(Roles.Manager) || user.IsInRole(Roles.Employee))
            {
                entities = entities
                    .Where(x => x.ManagerId == userId);
            }
            // For other future roles
            else
                return null;
            return entities;
        }
    }
}