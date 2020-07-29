using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    /// <summary>
    ///     Class for initial database initialization. Roles and several stub users will be generated.
    /// </summary>
    public class DbMigrator
    {
        public DbMigrator(ProjectDbContext dbContext, UserManager<Employee> userManager,
            RoleManager<IdentityRole<int>> roleManager)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            RoleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        private UserManager<Employee> UserManager { get; }
        private RoleManager<IdentityRole<int>> RoleManager { get; }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await TryAddUserRole(Roles.Leader);
            await TryAddUserRole(Roles.Manager);
            await TryAddUserRole(Roles.Employee);
        }

        private async Task<IdentityRole<int>> TryAddUserRole(string role)
        {
            var roleEntity = await RoleManager.FindByNameAsync(role);

            if (roleEntity == null)
            {
                roleEntity = new IdentityRole<int>(role);
                await RoleManager.CreateAsync(roleEntity);
            }

            return roleEntity;
        }

        private async Task<Employee> TryAddUser(Employee employee, string password, string role)
        {
            var userEntity = await UserManager.FindByEmailAsync(employee.Email);
            if (userEntity == null)
            {
                await UserManager.CreateAsync(employee, password);
                await UserManager.AddToRoleAsync(employee, role);
            }

            return userEntity;
        }
    }
}