using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using InvSys.Shared.Core.State;

namespace InvSys.Shared.State.EntityFramework.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected DbContext _dbContext;


        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<TEntity>> GetAll()
        {
            return _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            return _dbContext.Set<TEntity>().FirstAsync(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
