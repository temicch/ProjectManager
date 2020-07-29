using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        Task<int> AddAsync(T newEntity);
        Task<bool> RemoveAsyncById(int id);
        Task<int> UpdateAsync(T entity);
    }
}