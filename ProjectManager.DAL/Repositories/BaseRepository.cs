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
    public class BaseRepository<TEntity> : IRepository<Guid, TEntity> where TEntity : class, IBaseEntity<Guid>
    {
        private readonly ProjectDbContext _projectDbContext;
        private DbSet<TEntity> DbSet => _projectDbContext.Set<TEntity>();
        private readonly ILogger<BaseRepository<TEntity>> _logger;

        public BaseRepository(ProjectDbContext projectDbContext,
            ILogger<BaseRepository<TEntity>> logger)
        {
            _projectDbContext = projectDbContext;
            _logger = logger;
        }
        
        public async Task<Guid> AddAsync(TEntity newEntity)
        {
            try
            {
                await DbSet.AddAsync(newEntity);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Add error");
                return default;
            }

            return newEntity.Id;
        }

        public async Task<IEnumerable<TEntity>> GetByIdAsync(Guid Id)
        {
            return await DbSet
                .Where(x => x.Id == Id)
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

        public async Task<bool> RemoveByIdAsync(Guid id)
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
                _logger.LogError(exception, "RemoveById error");
                return false;
            }

            return true;
        }

        public Guid Update(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Update error");
                return default;
            }

            return entity.Id;
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _projectDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return false;
            }
        }
    }
}