using Microsoft.AspNetCore.Identity;
using ProjectManager.DAL;
using ProjectManager.DAL.Configuration;
using ProjectManager.DAL.Entities;
using System;
using System.Linq;

namespace ProjectManager.BLL
{
    public class DbMigrator
    {
        private const string Password = "adminPassword";

        public DbMigrator(ProjectDbContext context, 
            UserManager<Employee> userManager)
        {
            _projectDbContext = context;
            _userManager = userManager;
        }

        private readonly ProjectDbContext _projectDbContext;
        private readonly UserManager<Employee> _userManager;

        public void SeedEverything()
        {
            _projectDbContext.Database.EnsureCreated();

            if (_projectDbContext.Set<Employee>().Any())
            {
                return;
            }

            foreach (var entity in EmployeeConfiguration.Entities)
            {
                _userManager.CreateAsync(entity, Password).Wait();
            }

            _projectDbContext.Set<IdentityUserRole<Guid>>()
                .AddRange(UserRolesConfiguration.Entities);

            _projectDbContext.Set<Project>()
                .AddRange(ProjectConfiguration.Entities);

            _projectDbContext.Set<ProjectEmployees>()
                .AddRange(ProjectEmployeesConfiguration.Entities);

            _projectDbContext.Set<ProjectTask>()
                .AddRange(ProjectTaskConfiguration.Entities);

            _projectDbContext.SaveChanges();
        }
    }
}
