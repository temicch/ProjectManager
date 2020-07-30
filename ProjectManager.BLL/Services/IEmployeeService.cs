using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectManager.BLL.ViewModels;

namespace ProjectManager.BLL.Services
{
    public interface IEmployeeService : IService<EmployeeViewModel>
    {
        /// <summary>
        ///     Get all tasks by employee id
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="employeeId">Employee id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectTaskViewModel>> GetTasksAsync(ClaimsPrincipal user, int employeeId);

        /// <summary>
        ///     Get all the tasks of the employee for which he is the author
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="employeeId">Id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectTaskViewModel>> GetManagedTasksAsync(ClaimsPrincipal user, int employeeId);

        /// <summary>
        ///     Get all projects of an employee for which he is a manager
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="employeeId">Id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectViewModel>> GetAllManagedProjectsAsync(ClaimsPrincipal user, int employeeId);

        /// <summary>
        ///     Get all employee projects
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="employeeId">Id</param>
        /// <returns></returns>
        Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync(ClaimsPrincipal user, int employeeId);
    }
}