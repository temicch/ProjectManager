using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface IService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(ClaimsPrincipal user);
        Task<TEntity> GetByIdAsync(ClaimsPrincipal user, int id);
        Task<int> CreateAsync(ClaimsPrincipal user, TEntity entity);
        Task<int> EditAsync(ClaimsPrincipal user, TEntity entity);
        Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id);
    }
}
