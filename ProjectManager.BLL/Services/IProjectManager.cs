using ProjectManager.BLL.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface IProjectManager
    {
        Task<IEnumerable<ProjectViewModel>> GetAll();
        Task<IEnumerable<ProjectViewModel>> GetByEmployee(int employeeId);
        Task<ProjectViewModel> Get(int id);
        Task<int> CreateAsync(ClaimsPrincipal user, ProjectViewModel data);
        Task<int> EditAsync(ProjectViewModel task);
        Task<bool> Remove(int id);
    }
}
