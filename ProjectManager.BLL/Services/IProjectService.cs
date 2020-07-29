using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface IProjectService: IService<ProjectViewModel>
    {
        Task<IEnumerable<ProjectViewModel>> GetAllByEmployeeAsync(ClaimsPrincipal user, int employeeId);
        Task<bool> AddEmployeeAsync(ClaimsPrincipal user, int projectId, int employeeId);
        Task<IEnumerable<EmployeeViewModel>> GetEmployeesAsync(ClaimsPrincipal user, int projectId);
        Task<IEnumerable<ProjectTaskViewModel>> GetTasksAsync(ClaimsPrincipal user, int projectId);
    }
}