using ProjectManager.BLL.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface ITaskManager
    {
        IEnumerable<ProjectTaskViewModel> GetAll();
        IEnumerable<ProjectTaskViewModel> GetByEmployee(int employeeId);
        Task<ProjectTaskViewModel> Get(int id);
        Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskViewModel data);
        Task<int> EditAsync(ProjectTaskViewModel task);
        Task<bool> Remove(int id);
    }
}