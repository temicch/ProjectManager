using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeeService : IEmployeeService
    {
        private BaseRepository<Employee> Repository { get; }
        public BaseRepository<ProjectEmployees> PRepository { get; }
        private IMapper Mapper { get; }

        public EmployeeService(IMapper mapper, 
            BaseRepository<Employee> repository,
            BaseRepository<ProjectEmployees> pRepository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            PRepository = pRepository;
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<Guid> CreateAsync(ClaimsPrincipal user, EmployeeModel data)
        {
            if (!user.CanCreateEmployee())
                return default;

            var employee = Mapper.Map<Employee>(data);

            await Repository.AddAsync(employee);
            await Repository.SaveChangesAsync();

            return employee.Id;
        }

        public async Task<Guid> EditAsync(ClaimsPrincipal user, EmployeeModel employee)
        {
            if (!user.CanEditEmployee())
                return default;

            var entities = await Repository.GetByIdAsync(employee.Id);
            var entityToUpdate = entities.First();
            Mapper.Map(employee, entityToUpdate);

            var result = Repository.Update(entityToUpdate);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllAsync(ClaimsPrincipal user)
        {
            if (!user.CanLookAllEmployees())
                return null;

            return Mapper.Map<IEnumerable<EmployeeModel>>(await Repository
                .GetAllAsync());
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, Guid Id)
        {
            if (!user.CanRemoveEmployee())
                return false;

            var result = await Repository.RemoveByIdAsync(Id);
            await Repository.SaveChangesAsync();

            return result;
        }

        public async Task<EmployeeModel> GetAsync(ClaimsPrincipal user, Guid Id)
        {
            if (!user.CanLookEmployee())
                return null;

            var employee = await Repository.GetByIdAsync(Id);
            return Mapper.Map<EmployeeModel>(employee.FirstOrDefault());
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetTasksAsync(ClaimsPrincipal user, Guid employeeId)
        {
            if (!user.CanLookEmployee())
                return null;

            var employee = (await Repository.GetByIdAsync(employeeId)).FirstOrDefault();
            var tasks = employee.Tasks.ToList();

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetAllManagedTasksAsync(ClaimsPrincipal user, Guid employeeId)
        {
            if (!user.CanLookEmployee())
                return null;

            var employee = (await Repository.GetByIdAsync(employeeId)).FirstOrDefault();
            var tasks = employee.TasksAuthor.ToList();

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectModel>> GetAllManagedProjectsAsync(ClaimsPrincipal user, Guid employeeId)
        {
            if (!user.CanLookEmployee())
                return null;

            var employee = (await Repository.GetByIdAsync(employeeId)).FirstOrDefault();
            var projects = employee.ManagedProjects.ToList();

            return Mapper.Map<IEnumerable<ProjectModel>>(projects);
        }

        public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync(ClaimsPrincipal user, Guid employeeId)
        {
            if (!user.CanLookEmployee())
                return null;

            var employee = await PRepository
                .GetAsync(x => x.EmployeeId == employeeId);
            var projects = employee.ToList();

            return Mapper.Map<IEnumerable<ProjectModel>>(projects);
        }
    }
}