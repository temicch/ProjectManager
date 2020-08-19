using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectManager.DAL.Repositories
{
    /// <summary>
    ///     Main repository
    /// </summary>
    /// <typeparam name="TEntity">Entity for manipulate</typeparam>
    public class BaseRepository<TEntity> : IRepository<int, TEntity> where TEntity : class, IBaseEntity<int>
    {
        public BaseRepository(ProjectDbContext projectDbContext,
            ILogger<BaseRepository<TEntity>> logger)
        {
            ProjectDbContext = projectDbContext;
            Logger = logger;
        }

        public ProjectDbContext ProjectDbContext { get; protected set; }
        protected DbSet<TEntity> DbSet => ProjectDbContext.Set<TEntity>();
        private ILogger<BaseRepository<TEntity>> Logger { get; }

        public async Task<int> AddAsync(TEntity newEntity)
        {
            try
            {
                await DbSet.AddAsync(newEntity);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Add error");
                return 0;
            }

            return newEntity.Id;
        }

        public async Task<IEnumerable<TEntity>> GetByIdAsync(int id)
        {
            return await DbSet
                .Where(x => x.Id == id)
                .ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> selector)
        {
            return await DbSet
                .Where(selector)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var entity = await DbSet
                .FirstAsync(x => x.Id == id);
            if (entity == null)
                return false;
            try
            {
                DbSet.Remove(entity);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "RemoveById error");
                return false;
            }

            return true;
        }

        public int Update(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
            }
            catch (Exception exception)
            {
                Logger.LogError(exception, "Update error");
                return 0;
            }

            return entity.Id;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await ProjectDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Logger.LogError(e.Message);
                return false;
            }
        }
    }
}