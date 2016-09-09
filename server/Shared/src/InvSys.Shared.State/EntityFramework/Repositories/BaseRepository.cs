using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using InvSys.Shared.Core.Model;
using InvSys.Shared.Core.State;
using Microsoft.Extensions.Configuration;

namespace InvSys.Shared.State.EntityFramework.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected DbContext DbContext;

        protected BaseRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            return DbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<Page<TEntity>> GetPage(Query query)
        {
            var itemsPerPage = query.Filter.ItemsPerPage ?? 20;
            var itemsCount = await DbContext.Set<TEntity>().CountAsync();
            var itemsToSkip = (query.Filter.PageNumber - 1) * itemsPerPage;

            var page = new Page<TEntity> {CurrentPage = query.Filter.PageNumber, ItemsPerPage = itemsPerPage};
            page.TotalPages = (int) Math.Ceiling((double)itemsCount/page.ItemsPerPage);
            page.Items = await DbContext.Set<TEntity>().Skip(itemsToSkip).Take(itemsPerPage).ToListAsync();

            return page;
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            return DbContext.Set<TEntity>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual TEntity Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return (await DbContext.SaveChangesAsync()) > 0;
        }

        public virtual void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
