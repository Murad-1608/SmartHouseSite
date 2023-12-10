using Core.DataAccess;
using Core.Entity.Abstract;
using Entity.Concrete;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IProductDal : IRepositoryBase<Product>
    {
        Task<List<Product>> GetAllWithCategoryAsync(Expression<Func<Product, bool>> filter = null);

        Task<Product> GetByIdWithImageAsync(string id);
    }
}
