using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public class DBMigrator
    {
        private ProjectDbContext DbContext { get; }
        private UserManager<Employee> UserManager { get; }
        private RoleManager<IdentityRole<int>> RoleManager { get; }

        public DBMigrator(ProjectDbContext dbContext, UserManager<Employee> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            RoleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await DbContext.Database.MigrateAsync(cancellationToken);

            _ = await TryAddUserRole(Roles.Leader, cancellationToken);
            _ = await TryAddUserRole(Roles.Manager, cancellationToken);
            _ = await TryAddUserRole(Roles.Employee, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);

            _ = await TryAddAdminUser(cancellationToken);

            await DbContext.SaveChangesAsync(cancellationToken);
        }

        private async Task<IdentityRole<int>> TryAddUserRole(string role, CancellationToken cancellationToken)
        {
            var roleEntity = await RoleManager.FindByNameAsync(role);

            if (roleEntity == null)
            {
                roleEntity = new IdentityRole<int>(role);
                var task = await RoleManager.CreateAsync(roleEntity);
                
            }

            return roleEntity;
        }

        private async Task<Employee> TryAddAdminUser(CancellationToken cancellationToken)
        {
            var admin = await UserManager.FindByNameAsync("Admin");
            if (admin == null)
            {
                admin = new Employee("Admin")
                {
                    Email = "admin@admin.admin",
                    EmailConfirmed = true,
                };
                var user = await UserManager.CreateAsync(admin, "adminPassword");
                _ = await UserManager.AddToRoleAsync(admin, Roles.Leader);
            }

            return admin;
        }
    }
}
