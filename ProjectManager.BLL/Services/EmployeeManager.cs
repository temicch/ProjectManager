using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public class EmployeeManager: IEmployeeManager
    {
        private ProjectDbContext DBContext { get; }
        private IMapper Mapper { get; }

        public EmployeeManager(IMapper mapper, ProjectDbContext dbContext)
        {
            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, EmployeeViewModel data)
        {
            Employee employee = Mapper.Map<Employee>(data);

            await DBContext.Employees.AddAsync(employee);
            await DBContext.SaveChangesAsync();

            return employee.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<int> EditAsync(EmployeeViewModel employee)
        {
            DBContext.Employees.Update(Mapper.Map<Employee>(employee));
            await DBContext.SaveChangesAsync();

            return employee.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            await DBContext
                .Employees
                .LoadAsync();
            return DBContext
                .Employees
                .Select(x => Mapper.Map<EmployeeViewModel>(x));
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<bool> Remove(int id)
        {
            DBContext.Projects
                .Remove(DBContext.Projects
                    .Where(x => x.Id == id)
                    .FirstOrDefault()
                );
            await DBContext.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeViewModel> Get(int id)
        {
            await DBContext.Employees.LoadAsync();
            var employee = await DBContext.Employees.FindAsync(id);
            return employee == null ? null : Mapper.Map<EmployeeViewModel>(employee);
        }
    }
}
