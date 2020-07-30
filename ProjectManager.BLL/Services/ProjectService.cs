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
using System.Security.Principal;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService(
            IMapper mapper,
            BaseRepository<Project> repository,
            BaseRepository<ProjectEmployees> peRepository
            )
        {
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            PeRepository = peRepository ?? throw new ArgumentNullException(nameof(peRepository));
        }

        private IMapper Mapper { get; }
        private BaseRepository<Project> Repository { get; }
        private BaseRepository<ProjectEmployees> PeRepository { get; }

        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectViewModel data)
        {
            if (!IsHavePermissionForCreating(user))
                return 0;

            Project project = Mapper.Map<Project>(data);

            await Repository.AddAsync(project);

            return project.Id;
        }

        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectViewModel project)
        {
            if (!IsHavePermissionForEdit(user, Mapper.Map<Project>(project)))
                return 0;

            await Repository.UpdateAsync(Mapper.Map<Project>(project));

            return project.Id;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var entities = await GetAllFilteredEntitiesAsync(user);
            return Mapper.Map<IEnumerable<ProjectViewModel>>(entities);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetOfEmployeeAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var projects = Mapper.Map<IEnumerable<ProjectViewModel>>(await Repository.ProjectDbContext.ProjectEmployees
                .Include(x => x.Employee)
                .Include(x => x.Project)
                .Where(x => x.Employee.Id == employeeId)
                .ToListAsync());
            return projects;
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int projectId)
        {
            var project = await Repository.GetAsync(projectId);

            if (!IsHavePermissionForEdit(user, project))
                return false;

            var entityResult = await Repository.RemoveByIdAsync(projectId);
            return entityResult;
        }

        public async Task<ProjectViewModel> GetAsync(ClaimsPrincipal user, int projectId)
        {
            var project = await Repository.GetAsync(projectId);

            if (!IsHavePermissionForEdit(user, project))
                return null;

            return project == null ? null : Mapper.Map<ProjectViewModel>(project);
        }

        public async Task<bool> AddEmployeeAsync(ClaimsPrincipal user, int projectId, int employeeId)
        {
            var project = await Repository.GetAsync(projectId);

            if (!IsHavePermissionForEdit(user, project))
                return false;

            var entity = await Repository.ProjectDbContext.ProjectEmployees
                .AddAsync(new ProjectEmployees() { EmployeeId = employeeId, ProjectId = projectId });
            return entity.IsKeySet;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync(ClaimsPrincipal user, int projectId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var project = await Repository.GetAsync(projectId);

            if (!IsHavePermissionForEdit(user, project))
                return null;

            var employees = Mapper.Map<IEnumerable<EmployeeViewModel>>(await Repository.ProjectDbContext.ProjectEmployees
                .Where(x => x.ProjectId == projectId)
                .ToListAsync());
            return employees;
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetTasksAsync(ClaimsPrincipal user, int projectId)
        {
            var project = await Repository.GetAsync(projectId);

            if (!IsHavePermissionForEdit(user, project))
                return null;

            var tasks = Mapper.Map<IEnumerable<ProjectTaskViewModel>>(await Repository
                .GetAll()
                .Where(x => x.Id == projectId)
                .Select(x => x.Tasks)
                .ToListAsync());
            return tasks;
        }

        private bool IsHavePermissionForLook(ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }

        private bool IsHavePermissionForEdit(ClaimsPrincipal user, Project project)
        {
            if (project == null)
                return false;

            var userId = user.GetLoggedInUserId<int>();

            return user.IsInRole(Roles.Leader) || 
                project.ManagerId == userId ||
                Repository.ProjectDbContext.ProjectEmployees
                .Where(x => x.ProjectId == project.Id && x.EmployeeId == userId)
                .Count() > 0;
        }
        private bool IsHavePermissionForCreating(ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader) || user.IsInRole(Roles.Manager);
        }

        private async Task<IEnumerable<Project>> GetAllFilteredEntitiesAsync(ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
                return null;

            IEnumerable<Project> entities = Repository.GetAll();
            var userId = user.GetLoggedInUserId<int>();

            // Leader can view any projects, so nothing filter to
            if (user.IsInRole(Roles.Leader))
            {
            }
            // Other roles can see only theirs projects. Filter it
            else if (user.IsInRole(Roles.Manager) || user.IsInRole(Roles.Employee))
            {
                entities = entities
                    .Where(x => x.ManagerId == userId)
                    .ToList();

                entities = entities.Union(await PeRepository
                    .GetAll()
                    .Where(x => x.EmployeeId == userId)
                    .Select(x => x.Project).ToListAsync());
            }
            // For other future roles
            else
                return null;
            return entities;
        }
    }
}