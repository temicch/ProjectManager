using Microsoft.AspNetCore.Authorization;
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
    class EmployeeManager: IEmployeeManager
    {
        private ProjectDbContext DBContext { get; }

        public EmployeeManager(ProjectDbContext dbContext)
        {
            DBContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<int> CreateAsync(ClaimsPrincipal user, EmployeeViewModel data)
        {
            Employee employee = (Employee)(IEmployee)data;

            await DBContext.Employees.AddAsync(employee);
            await DBContext.SaveChangesAsync();

            return employee.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        public async Task<int> EditAsync(EmployeeViewModel employee)
        {
            DBContext.Employees.Update((Employee)(IEmployee)employee);
            await DBContext.SaveChangesAsync();

            return employee.Id;
        }

        [Authorize(Roles = Roles.Leader)]
        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return DBContext.Employees
                .Select(x => new EmployeeViewModel(/*x*/));
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
            var employee = await DBContext.Employees.FindAsync(id);
            return employee == null ? null : new EmployeeViewModel(/*employee*/);
        }
    }
}
