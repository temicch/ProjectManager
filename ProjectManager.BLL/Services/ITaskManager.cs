using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface ITaskManager
    {
        IEnumerable<TaskViewModel> GetAll();
        IEnumerable<TaskViewModel> GetByEmployee(int employeeId);
        Task<TaskViewModel> Get(int id);
        Task<int> CreateAsync(ClaimsPrincipal user, TaskViewModel data);
        Task<int> EditAsync(TaskViewModel task);
        Task<bool> Remove(int id);
    }
}
