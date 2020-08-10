using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        ///     Get entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetByIdAsync(int id);

        /// <summary>
        /// Get entity by specified condition
        /// </summary>
        /// <param name="selector">Selector</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> selector);

        /// <summary>
        ///     Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        ///     Add new entity
        /// </summary>
        /// <param name="newEntity">Entity</param>
        /// <returns><seealso cref="Id" /> of successfully added entity, 0 otherwise</returns>
        Task<int> AddAsync(T newEntity);

        /// <summary>
        ///     Remove specified by Id entity
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns><paramref name="true"/> if entity was successfully removed, <paramref name="false"/> otherwise</returns>
        Task<bool> RemoveByIdAsync(int id);

        /// <summary>
        ///     Edit entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><seealso cref="Id" /> of successfully edited entity, 0 otherwise</returns>
        Task<int> UpdateAsync(T entity);
    }
}