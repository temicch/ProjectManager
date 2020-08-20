using System;
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
        ///     Get an entity by its Id
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="Id">Id of entity</param>
        /// <returns>
        ///     <typeparamref name="TEntity" />
        /// </returns>
        Task<TEntity> GetAsync(ClaimsPrincipal user, Guid Id);

        /// <summary>
        ///     Create entity
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="Id">Id of entity</param>
        /// <returns><paramref name="Id" /> of successfully created entity, 0 otherwise</returns>
        Task<Guid> CreateAsync(ClaimsPrincipal user, TEntity entity);

        /// <summary>
        ///     Edit entity
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="entity">Entity to edit</param>
        /// <returns><paramref name="Id" /> of successfully edited entity, 0 otherwise</returns>
        Task<Guid> EditAsync(ClaimsPrincipal user, TEntity entity);

        /// <summary>
        ///     Remove entity by its Id
        /// </summary>
        /// <param name="user">User principal</param>
        /// <param name="Id">Id of entity</param>
        /// <returns><paramref name="True" /> if its removed, <paramref name="False" /> otherwise</returns>
        Task<bool> RemoveByIdAsync(ClaimsPrincipal user, Guid Id);
    }
}