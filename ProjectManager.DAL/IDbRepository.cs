using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.DAL
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>();
        IQueryable<T> Get<T>(Expression<Func<T, bool>> selector);
        Task<Guid> AddAsync<T>(T newEntity);
        Task RemoveAsync<T>(Guid id);
        Task UpdateAsync<T>(T entity);
        Task<int> SaveChangesAsync();
    }
}
