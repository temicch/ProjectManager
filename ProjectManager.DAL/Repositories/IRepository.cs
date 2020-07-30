using System.Linq;
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
        Task<T> GetAsync(int id);

        /// <summary>
        ///     Get all entities as <seealso cref="IQueryable" />
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

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
        /// <returns></returns>
        Task<bool> RemoveByIdAsync(int id);

        /// <summary>
        ///     Edit entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns><seealso cref="Id" /> of successfully edited entity, 0 otherwise</returns>
        Task<int> UpdateAsync(T entity);
    }
}