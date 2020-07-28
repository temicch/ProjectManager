using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public BaseRepository(ProjectDbContext projectDbContext)
        {
            ProjectDbContext = projectDbContext;
        }

        public ProjectDbContext ProjectDbContext { get; protected set; }
        protected DbSet<T> DbSet { get; set; }

        public virtual async Task<int> AddAsync(T newEntity)
        {
            await DbSet.AddAsync(newEntity);
            await ProjectDbContext.SaveChangesAsync();
            return newEntity.Id;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await GetAllAsQuery()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public virtual IQueryable<T> GetAll()
        {
            return GetAllAsQuery();
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entity = DbSet
                .Where(x => x.Id == id)
                .FirstOrDefault();
            DbSet.Remove(entity);
            await ProjectDbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await ProjectDbContext.SaveChangesAsync();
        }

        protected abstract IQueryable<T> GetAllAsQuery();
    }
}