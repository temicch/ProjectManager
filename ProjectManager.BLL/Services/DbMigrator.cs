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
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            RoleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        private ProjectDbContext DbContext { get; }
        private UserManager<Employee> UserManager { get; }
        private RoleManager<IdentityRole<int>> RoleManager { get; }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await DbContext.Database.MigrateAsync(cancellationToken);

            await TryAddUserRole(Roles.Leader);
            await TryAddUserRole(Roles.Manager);
            await TryAddUserRole(Roles.Employee);

            await TryAddUser(
                new Employee("admin@email.com")
                {
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                    FirstName = "Admin",
                    LastName = "Hard"
                },
                "adminPassword",
                Roles.Leader);
            await DbContext.SaveChangesAsync(cancellationToken);

            await TryAddUser(
                new Employee("manager@email.com")
                {
                    Email = "manager@email.com",
                    EmailConfirmed = true,
                    FirstName = "Manager",
                    LastName = "Middle"
                },
                "adminPassword",
                Roles.Leader);
            await DbContext.SaveChangesAsync(cancellationToken);

            await TryAddUser(
                new Employee("employee@email.com")
                {
                    Email = "employee@email.com",
                    EmailConfirmed = true,
                    FirstName = "Employee",
                    LastName = "Simple"
                },
                "adminPassword",
                Roles.Leader);
            await DbContext.SaveChangesAsync(cancellationToken);
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