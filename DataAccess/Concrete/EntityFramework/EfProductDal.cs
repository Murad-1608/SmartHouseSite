using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfRepositoryBase<Product, AppDbContext>, IProductDal
    {
        public async Task<List<Product>> GetAllWithCategoryAsync(Expression<Func<Product, bool>> filter = null)
        {
            using (AppDbContext context = new())
            {
                return filter == null ? await context.Products.Include(x => x.Category).ToListAsync() :
                                        await context.Products.Where(filter).Include(x => x.Category).ToListAsync();
            }
        }

        public async Task<Product> GetByIdWithImageAsync(string id)
        {
            using (AppDbContext context = new())
            {
                return await context.Products.Include(x => x.Images).FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
        }
    }
}
