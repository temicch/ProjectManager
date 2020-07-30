using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjectManager.BLL.ViewModels;

namespace ProjectManager.BLL.Services
{
    public interface ITaskService : IService<ProjectTaskViewModel>
    {
        /// <summary>
        ///     Get tasks of specified <seealso cref="Employee" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectTaskViewModel>> GetOfEmployeeIdAsync(ClaimsPrincipal user, int employeeId);
    }
}