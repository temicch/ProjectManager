using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;
using ProjectManager.DAL.Extensions;

namespace ProjectManager.DAL.Repositories
{
    /// <summary>
    ///     Facade for repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IBaseEntity
    {
        public BaseRepository(ProjectDbContext projectDbContext,
            DbSet<T> dbSet,
            ILogger logger)
        {
            ProjectDbContext = projectDbContext;
            DbSet = dbSet;
            Logger = logger;
        }

        public ProjectDbContext ProjectDbContext { get; protected set; }
        protected DbSet<T> DbSet { get; set; }
        private ILogger Logger { get; }

        public virtual async Task<int> AddAsync(T newEntity)
        {
            try
            {
                await DbSet.AddAsync(newEntity);
                await ProjectDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Add error");
                return 0;
            }

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
            try
            {
                ProjectDbContext.DetachLocal(entity, entity.Id);
                ProjectDbContext.Remove(entity);
                await ProjectDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "RemoveById error");
                return false;
            }

            return true;
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            try
            {
                ProjectDbContext.DetachLocal(entity, entity.Id);
                ProjectDbContext.Update(entity);
                await ProjectDbContext.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Update error");
                return 0;
            }

            return entity.Id;
        }

        protected abstract IQueryable<T> GetAllAsQuery();
    }
}