using ProjectManager.DAL.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    interface IProjectManager
    {
        IEnumerable<IProject> GetAll();
        IEnumerable<IProject> GetByEmployee(IEmployee employee);
        Task<int> CreateAsync(ClaimsPrincipal user, ProjectViewModel data);
        Task<int> EditAsync(ProjectViewModel project);
        bool Remove(IProject project);
    }
}
