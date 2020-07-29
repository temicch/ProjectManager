using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IMapper mapper
            , BaseRepository<Employee> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        private BaseRepository<Employee> Repository { get; }
        private IMapper Mapper { get; }

        [Authorize(Roles = Roles.Leader)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, EmployeeViewModel data)
        {
            Employee employee = Mapper.Map<Employee>(data);

            await Repository.AddAsync(employee);

            return employee.Id;
        }

        //[Authorize(Roles = Roles.Leader)]
        public async Task<int> EditAsync(ClaimsPrincipal user, EmployeeViewModel employee)
        {
            await Repository.UpdateAsync(Mapper.Map<Employee>(employee));

            return employee.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        [Authorize(Roles = Roles.Manager)]
        public async Task<IEnumerable<EmployeeViewModel>> GetAllAsync(ClaimsPrincipal user)
        {
            return Mapper.Map<IEnumerable<EmployeeViewModel>>(await Repository
                .GetAll()
                .ToListAsync());
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id)
        {
            await Repository.RemoveAsyncById(id);
            return true;
        }

        public async Task<EmployeeViewModel> GetByIdAsync(ClaimsPrincipal user, int id)
        {
            var employee = await Repository.GetAsync(id);
            return employee == null ? null : Mapper.Map<EmployeeViewModel>(employee);
        }

        public async Task<IEnumerable<ProjectTaskViewModel>> GetAllTasksAsync(ClaimsPrincipal user, int employeeId)
        {
            var employee = await Repository.GetAsync(employeeId);
            var tasks = employee.Tasks.ToList();

            return Mapper.Map<IEnumerable<ProjectTaskViewModel>>(tasks);
        }
        public async Task<IEnumerable<ProjectTaskViewModel>> GetAllManagedTasksAsync(ClaimsPrincipal user, int employeeId)
        {
            var employee = await Repository.GetAsync(employeeId);
            var tasks = employee.TasksAuthor.ToList();

            return Mapper.Map<IEnumerable<ProjectTaskViewModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllManagedProjectsAsync(ClaimsPrincipal user, int employeeId)
        {
            var employee = await Repository.GetAsync(employeeId);
            var projects = employee.ManagedProjects.ToList();

            return Mapper.Map<IEnumerable<ProjectViewModel>>(projects);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync(ClaimsPrincipal user, int employeeId)
        {
            var employee = Repository.ProjectDbContext.ProjectEmployees
                .Where(x => x.EmployeeId == employeeId);
            var projects = await employee.ToListAsync();

            return Mapper.Map<IEnumerable<ProjectViewModel>>(projects);
        }
    }
}