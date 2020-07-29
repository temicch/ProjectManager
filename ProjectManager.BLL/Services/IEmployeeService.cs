using ProjectManager.BLL.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface IEmployeeService : IService<EmployeeViewModel>
    {
        Task<IEnumerable<ProjectTaskViewModel>> GetAllTasksAsync(ClaimsPrincipal user, int employeeId);
        Task<IEnumerable<ProjectTaskViewModel>> GetAllManagedTasksAsync(ClaimsPrincipal user, int employeeId);
        Task<IEnumerable<ProjectViewModel>> GetAllManagedProjectsAsync(ClaimsPrincipal user, int employeeId);
        Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync(ClaimsPrincipal user, int employeeId);
    }
}