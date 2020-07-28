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
    public class EmployeeManager : IEmployeeManager
    {
        public EmployeeManager(IMapper mapper, BaseRepository<Employee> repository)
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

        [Authorize(Roles = Roles.Leader)]
        public async Task<int> EditAsync(EmployeeViewModel employee)
        {
            await Repository.UpdateAsync(Mapper.Map<Employee>(employee));

            return employee.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return Repository
                .GetAll()
                .Select(x => Mapper.Map<EmployeeViewModel>(x));
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<bool> Remove(int id)
        {
            await Repository.RemoveAsync(id);
            return true;
        }

        public async Task<EmployeeViewModel> Get(int id)
        {
            var employee = await Repository.GetAsync(id);
            return employee == null ? null : Mapper.Map<EmployeeViewModel>(employee);
        }
    }
}