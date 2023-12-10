using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly IImageService imageService;
        public ProductController(IProductService productService,
                                 ICategoryService categoryService,
                                 IImageService imageService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.imageService = imageService;
        }

        public async Task<IActionResult> Index(string search = null)
        {
            List<Product> products;

            if (search == null)
                products = await productService.GetAllWithCategory();
            else
                products = await productService.Search(search);

            return View(products);
        }

        public async Task<IActionResult> FilterByCategory(string categoryId = null)
        {
            var values = await productService.FilterByCategory(categoryId);
            var category = await categoryService.GetById(categoryId);

            ViewBag.Category = category;

            return View(values);
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            var product = await productService.GetById(id);

            return View(product);
        }
    }


}
