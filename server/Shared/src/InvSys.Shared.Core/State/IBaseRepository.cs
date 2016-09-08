using System.Collections.Generic;
using System.Threading.Tasks;
using InvSys.Shared.Core.Model;

namespace InvSys.Shared.Core.State
{
    public interface IBaseRepository<TEntity, in TKey>
        where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<Page<TEntity>> GetPage(Filter filter);
        Task<TEntity> Get(TKey id);
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TKey id);
        void Update(TEntity entity);
        Task<bool> SaveChangesAsync();
    }
}
