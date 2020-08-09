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

        public async Task<int> CreateAsync(ClaimsPrincipal user, EmployeeModel data)
        {
            if (!IsHavePermissionForEdit(user))
                return 0;

            var employee = Mapper.Map<Employee>(data);

            await Repository.AddAsync(employee);

            return employee.Id;
        }

        public async Task<int> EditAsync(ClaimsPrincipal user, EmployeeModel employee)
        {
            if (!IsHavePermissionForEdit(user))
                return 0;

            await Repository.UpdateAsync(Mapper.Map<Employee>(employee));

            return employee.Id;
        }

        public IEnumerable<EmployeeModel> GetAll(ClaimsPrincipal user)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            return Mapper.Map<IEnumerable<EmployeeModel>>(Repository
                .GetAll()
                .ToList());
        }

        public async Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id)
        {
            if (!IsHavePermissionForEdit(user))
                return false;
            return await Repository.RemoveByIdAsync(id);
        }

        public async Task<EmployeeModel> GetAsync(ClaimsPrincipal user, int id)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var employee = await Repository.GetByIdAsync(id);
            return employee == null ? null : Mapper.Map<EmployeeModel>(employee);
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetTasksAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var employee = (await Repository.GetByIdAsync(employeeId)).FirstOrDefault();
            var tasks = employee.Tasks.ToList();

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectTaskModel>> GetManagedTasksAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var employee = (await Repository.GetByIdAsync(employeeId)).FirstOrDefault();
            var tasks = employee.TasksAuthor.ToList();

            return Mapper.Map<IEnumerable<ProjectTaskModel>>(tasks);
        }

        public async Task<IEnumerable<ProjectModel>> GetAllManagedProjectsAsync(ClaimsPrincipal user,
            int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var employee = (await Repository.GetByIdAsync(employeeId)).FirstOrDefault();
            var projects = employee.ManagedProjects.ToList();

            return Mapper.Map<IEnumerable<ProjectModel>>(projects);
        }

        public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync(ClaimsPrincipal user, int employeeId)
        {
            if (!IsHavePermissionForLook(user))
                return null;

            var employee = Repository.ProjectDbContext.ProjectEmployees
                .Where(x => x.EmployeeId == employeeId);
            var projects = await employee.ToListAsync();

            return Mapper.Map<IEnumerable<ProjectModel>>(projects);
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