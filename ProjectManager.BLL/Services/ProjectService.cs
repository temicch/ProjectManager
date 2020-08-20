using AutoMapper;
using ProjectManager.BLL.Extensions;
using ProjectManager.BLL.Models;
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

        public async Task<Guid> CreateAsync(ClaimsPrincipal user, ProjectModel data)
        {
            if (!user.CanCreateProject())
                return default;

            var project = Mapper.Map<Project>(data);

            var result = await Repository.AddAsync(project);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<Guid> EditAsync(ClaimsPrincipal user, ProjectModel project)
        {
            if (!user.CanEditProject(project))
                return default;

            var entities = await Repository.GetByIdAsync(project.Id);
            var entityToUpdate = entities.First();
            Mapper.Map(project, entityToUpdate);

            var result = Repository.Update(entityToUpdate);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<ProjectModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!user.CanLookAllProjects())
                return null;

            var projects = await Repository.GetAllAsync();

            return Mapper.Map<IEnumerable<ProjectModel>>(projects);
        }

        public async Task<IEnumerable<ProjectModel>> GetOfEmployeeAsync(ClaimsPrincipal user, Guid employeeId)
        {
            if (!user.CanLookProject())
                return null;

            var projects = await PeRepository.GetAsync(x => x.Employee.Id == employeeId);

            return Mapper.Map<IEnumerable<ProjectModel>>(projects.ToList());
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, Guid projectId)
        {
            var project = (await Repository
                .GetByIdAsync(projectId))
                .FirstOrDefault();

            if (!user.CanRemoveProject(Mapper.Map<ProjectModel>(project)))
                return false;

            var result = await Repository.RemoveByIdAsync(projectId);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<ProjectModel> GetAsync(ClaimsPrincipal user, Guid projectId)
        {
            if (!user.CanLookProject())
                return null;

            var project = (await Repository.GetByIdAsync(projectId)).FirstOrDefault();

            return Mapper.Map<ProjectModel>(project);
        }

        public async Task<bool> AddEmployeeAsync(ClaimsPrincipal user, Guid projectId, Guid employeeId)
        {
            var project = Mapper.Map<ProjectModel>((await Repository
                .GetByIdAsync(projectId))
                .FirstOrDefault());

            if (!user.CanEditProject(project))
                return false;

            var entity = await PeRepository
                .AddAsync(new ProjectEmployees {EmployeeId = employeeId, ProjectId = projectId});

            await Repository.SaveChangesAsync();

            return default(Guid).CompareTo(entity) != 0;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(ClaimsPrincipal user, Guid projectId)
        {
            if (!user.CanLookProject())
                return null;

            var entities = await PeRepository.GetAsync(x => x.ProjectId == projectId);

            var employees = Mapper.Map<IEnumerable<EmployeeModel>>(entities.Select(x => x.Employee));

            return employees;
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetTasksAsync(ClaimsPrincipal user, Guid projectId)
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