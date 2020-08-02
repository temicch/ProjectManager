using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectManager.BLL.Models;

namespace ProjectManager.BLL.Services
{
    public interface IProjectService : IService<ProjectModel>
    {
        /// <summary>
        ///     Get all projects of specified employee id
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="employeeId">Employee id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectModel>> GetOfEmployeeAsync(ClaimsPrincipal user, int employeeId);

        /// <summary>
        ///     Add an employee to a project
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="projectId">Project id</param>
        /// <param name="employeeId">Employee id</param>
        /// <returns><paramref name="True" /> if employee was successfully added, <paramref name="False" /> otherwise</returns>
        Task<bool> AddEmployeeAsync(ClaimsPrincipal user, int projectId, int employeeId);

        /// <summary>
        ///     Get employees on project
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="projectId">Project id</param>
        /// <returns></returns>
        Task<IEnumerable<EmployeeModel>> GetEmployeesAsync(ClaimsPrincipal user, int projectId);

        /// <summary>
        ///     Get tasks of project
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="projectId">Project id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectTaskModel>> GetTasksAsync(ClaimsPrincipal user, int projectId);
    }
}