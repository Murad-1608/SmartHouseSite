using Core.Entity.Abstract;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepositoryBase<TEntity>
         where TEntity : class, IEntity, new()
    {
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    }
}
