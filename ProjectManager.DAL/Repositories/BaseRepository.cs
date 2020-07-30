using Microsoft.EntityFrameworkCore;
using ProjectManager.DAL.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public BaseRepository(ProjectDbContext projectDbContext, DbSet<T> dbSet)
        {
            ProjectDbContext = projectDbContext;
            DbSet = dbSet;
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

        public virtual async Task<bool> RemoveByIdAsync(int id)
        {
            var entity = await DbSet
                .FirstAsync(x => x.Id == id);
            if (entity == null)
                return false;
            DbSet.Remove(entity);
            await ProjectDbContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await ProjectDbContext.SaveChangesAsync();
            return entity.Id;
        }

        protected abstract IQueryable<T> GetAllAsQuery();
    }
}