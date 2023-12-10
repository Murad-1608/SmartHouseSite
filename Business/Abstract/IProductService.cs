using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllWithCategory();
        Task Add(Product product, List<IFormFile> photos);
        Task Delete(string id);
        Task<List<Product>> FilterByCategory(string categoryId);
        Task<Product> GetById(string id);
        Task<List<Product>> Search(string word);
        List<Product> Last3Product();
    }
}
