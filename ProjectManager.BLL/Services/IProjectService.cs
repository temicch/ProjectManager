using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectManager.BLL.Models;

namespace ProjectManager.BLL.Services
{
    public interface IProjectService : IService<ProjectModel>
    {
        /// <summary>
        ///     Get all projects of specified employee Id
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="employeeId">Employee Id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectModel>> GetOfEmployeeAsync(ClaimsPrincipal user, Guid employeeId);

        /// <summary>
        ///     Add an employee to a project
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="projectId">Project Id</param>
        /// <param name="employeeId">Employee Id</param>
        /// <returns><paramref name="True" /> if employee was successfully added, <paramref name="False" /> otherwise</returns>
        Task<bool> AddEmployeeAsync(ClaimsPrincipal user, Guid projectId, Guid employeeId);

        /// <summary>
        ///     Get employees on project
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="projectId">Project Id</param>
        /// <returns></returns>
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(ClaimsPrincipal user, Guid projectId);

        /// <summary>
        ///     Get tasks of project
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="projectId">Project Id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectTaskModel>> GetTasksAsync(ClaimsPrincipal user, Guid projectId);
    }
}