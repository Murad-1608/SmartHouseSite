using Business.Abstract;
using Business.Helper;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal productDal;
        private readonly IImageService imageService;

        public ProductManager(IProductDal productDal, IImageService imageService)
        {
            this.productDal = productDal;
            this.imageService = imageService;
        }

        public async Task Add(Product product, List<IFormFile> photos)
        {
            await productDal.AddAsync(product);
            if (photos != null)
            {
                foreach (var item in photos)
                {
                    Image image = new()
                    {
                        ProductId = product.Id,
                        Name = SystemIOOperations.AddPhoto(item, "Product")
                    };
                    await imageService.Add(image);
                }
            }

        }

        public async Task Delete(string id)
        {
            var product = await productDal.GetByIdWithImageAsync(id);

            SystemIOOperations.DeletePhoto("Product", product.PhotoUrl);

            foreach (var item in product.Images)
            {
                SystemIOOperations.DeletePhoto("Product", item.Name);
            }

            await productDal.DeleteAsync(product);
        }

        public async Task<List<Product>> FilterByCategory(string categoryId)
        {
            var values = await productDal.GetAllAsync(x => x.CategoryId.ToString() == categoryId);

            return values;
        }

        public async Task<List<Product>> GetAllWithCategory()
        {
            var product = await productDal.GetAllWithCategoryAsync();
            product.Reverse();
            return product;
        }

        public async Task<Product> GetById(string id)
        {
            var product = await productDal.GetByIdWithImageAsync(id);

            return product;
        }

        public List<Product> Last3Product()
        {
            var product = productDal.GetAllWithCategoryAsync().Result.TakeLast(3).ToList();

            return product;
        }

        public async Task<List<Product>> Search(string word)
        {
            var values = await productDal.GetAllWithCategoryAsync(x => x.Name.Contains(word) ||
                                                                       x.Description.Contains(word));

            return values;
        }
    }
}
