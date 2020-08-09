using ProjectManager.BLL.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface ITaskService : IService<ProjectTaskModel>
    {
        /// <summary>
        ///     Get tasks of specified <seealso cref="Employee" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        IEnumerable<ProjectTaskModel> GetOfEmployee(ClaimsPrincipal user, int employeeId);
    }
}