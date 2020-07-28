using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
        Task<int> AddAsync(T newEntity);
        Task RemoveAsync(int id);
        Task UpdateAsync(T entity);
    }
}
