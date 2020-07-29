using ProjectManager.BLL.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface ITaskService : IService<ProjectTaskViewModel>
    {
        Task<IEnumerable<ProjectTaskViewModel>> GetAllByEmployeeAsync(ClaimsPrincipal user, int employeeId);
    }
}