using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public interface IRepository<TKey, TEntity>
    {
        /// <summary>
        ///     Get entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetByIdAsync(TKey id);

        /// <summary>
        /// Get entity by specified condition
        /// </summary>
        /// <param name="selector">Selector</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> selector);

        /// <summary>
        ///     Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        ///     Add new entity
        /// </summary>
        /// <param name="newEntity">Entity</param>
        /// <returns><seealso cref="Id" /> of successfully added entity, 0 otherwise</returns>
        Task<TKey> AddAsync(TEntity newEntity);

        /// <summary>
        ///     Remove specified by Id entity
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><paramref name="true"/> if entity was successfully removed, <paramref name="false"/> otherwise</returns>
        Task<bool> RemoveByIdAsync(TKey id);

        /// <summary>
        ///     Edit entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><seealso cref="Id" /> of successfully edited entity, 0 otherwise</returns>
        TKey Update(TEntity entity);

        Task<bool> SaveChangesAsync();
    }
}