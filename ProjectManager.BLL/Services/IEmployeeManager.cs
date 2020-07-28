using ProjectManager.BLL.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface IEmployeeManager
    {
        IEnumerable<EmployeeViewModel> GetAll();
        Task<EmployeeViewModel> Get(int id);
        Task<int> CreateAsync(ClaimsPrincipal user, EmployeeViewModel data);
        Task<int> EditAsync(EmployeeViewModel task);
        Task<bool> Remove(int id);
    }
}
