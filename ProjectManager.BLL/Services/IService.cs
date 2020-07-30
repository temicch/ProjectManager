using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface IService<TEntity>
    {
        /// <summary>
        ///     Get all entities
        /// </summary>
        /// <param name="user">User principal</param>
        /// <returns><typeparamref name="TEntity" /> enumerable</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(ClaimsPrincipal user);

        /// <summary>
        ///     Get an entity by its ID
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="id">Id of entity</param>
        /// <returns>
        ///     <typeparamref name="TEntity" />
        /// </returns>
        Task<TEntity> GetAsync(ClaimsPrincipal user, int id);

        /// <summary>
        ///     Create entity
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="id">Id of entity</param>
        /// <returns><paramref name="Id" /> of successfully created entity, 0 otherwise</returns>
        Task<int> CreateAsync(ClaimsPrincipal user, TEntity entity);

        /// <summary>
        ///     Edit entity
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="entity">Entity to edit</param>
        /// <returns><paramref name="Id" /> of successfully edited entity, 0 otherwise</returns>
        Task<int> EditAsync(ClaimsPrincipal user, TEntity entity);

        /// <summary>
        ///     Remove entity by its id
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="id">Id of entity</param>
        /// <returns><paramref name="True" /> if its removed, <paramref name="False" /> otherwise</returns>
        Task<bool> RemoveByIdAsync(ClaimsPrincipal user, int id);
    }
}