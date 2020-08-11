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

        public async Task<int> CreateAsync(ClaimsPrincipal user, ProjectModel data)
        {
            if (!user.CanCreateProject())
                return 0;

            var project = Mapper.Map<Project>(data);

            var result = await Repository.AddAsync(project);

            return result;
        }

        public async Task<int> EditAsync(ClaimsPrincipal user, ProjectModel project)
        {
            if (!user.CanEditProject(project))
                return 0;

            var result = await Repository.UpdateAsync(Mapper.Map<Project>(project));

            return result;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!user.CanLookAllProjects())
                return null;

            var projects = await Repository.GetAllAsync();

            return Mapper.Map<IEnumerable<ProjectModel>>(projects);
        }

        public async Task<IEnumerable<ProjectModel>> GetOfEmployeeAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!user.CanLookProject())
                return null;

            var projects = await PeRepository.GetAsync(x => x.Employee.Id == employeeId);

            return Mapper.Map<IEnumerable<ProjectModel>>(projects.ToList());
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int projectId)
        {
            var project = (await Repository
                .GetByIdAsync(projectId))
                .FirstOrDefault();

            if (!user.CanRemoveProject(Mapper.Map<ProjectModel>(project)))
                return false;

            var result = await Repository.RemoveByIdAsync(projectId);

            return result;
        }

        public async Task<ProjectModel> GetAsync(ClaimsPrincipal user, int projectId)
        {
            if (!user.CanLookProject())
                return null;

            var project = (await Repository.GetByIdAsync(projectId)).FirstOrDefault();

            return Mapper.Map<ProjectModel>(project);
        }

        public async Task<bool> AddEmployeeAsync(ClaimsPrincipal user, int projectId, int employeeId)
        {
            var project = Mapper.Map<ProjectModel>((await Repository
                .GetByIdAsync(projectId))
                .FirstOrDefault());

            if (!user.CanEditProject(project))
                return false;

            var entity = await PeRepository
                .AddAsync(new ProjectEmployees {EmployeeId = employeeId, ProjectId = projectId});
            return entity > 0;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(ClaimsPrincipal user, int projectId)
        {
            if (!user.CanLookProject())
                return null;

            var entities = await PeRepository.GetAsync(x => x.ProjectId == projectId);

            var employees = Mapper.Map<IEnumerable<EmployeeModel>>(entities.Select(x => x.Employee));

            return employees;
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetTasksAsync(ClaimsPrincipal user, int projectId)
        {
            if (!user.CanLookProject())
                return null;

            var entities = await Repository.GetAsync(x => x.Id == projectId);

            var tasks = Mapper.Map<IEnumerable<ProjectTaskModel>>(entities
                .Select(x => x.Tasks));

            return tasks;
        }
    }
}