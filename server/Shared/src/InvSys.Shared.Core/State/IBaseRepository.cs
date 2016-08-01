using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvSys.Shared.Core.State
{
    public interface IBaseRepository<TEntity, in TKey>
        where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(TKey id);
        TEntity Add(TEntity entity);
        void Delete(TKey id);
        void Update(TEntity entity);
        Task<bool> SaveChangesAsync();
    }
}
