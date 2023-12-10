using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.ViewModels;

namespace WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        public ProductController(IProductService productService,
                                 ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await productService.GetAllWithCategory();

            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> categories = (from i in categoryService.GetAll().Result.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.Name,
                                                   Value = i.Id.ToString()
                                               }).ToList();

            ProductViewModel viewmodel = new()
            {
                Categories = categories
            };

            return View(viewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel viewModel)
        {
            //Image validation
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (viewModel.ProductModel.BasePhoto.ContentType != "image/jpeg" && viewModel.ProductModel.BasePhoto.ContentType != "image/png")
            {
                ModelState.AddModelError(nameof(viewModel.ProductModel.BasePhoto), "Şəkil formatı düzgün deyildir");
                return View();
            }
            if (viewModel.ProductModel.PhotoUrls != null)
            {
                foreach (var item in viewModel.ProductModel.PhotoUrls!)
                {
                    if (viewModel.ProductModel.PhotoUrls == null)
                    {
                        break;
                    }
                    if (item.ContentType != "image/jpeg" && item.ContentType != "image/png")
                    {
                        ModelState.AddModelError(nameof(viewModel.ProductModel.BasePhoto), "Şəkil formatı düzgün deyildir");
                        return View();
                    }
                }
            }
            // Create new product
            Product product = new()
            {
                Name = viewModel.ProductModel.Name,
                Description = viewModel.ProductModel.Description,
                PhotoUrl = SystemIOOperations.AddPhoto(viewModel.ProductModel.BasePhoto, "Product"),
                CategoryId = new Guid(viewModel.ProductModel.CategoryId)
            };
            await productService.Add(product, viewModel.ProductModel.PhotoUrls);

            return RedirectPermanent("/admin/product");
        }

        public async Task<IActionResult> Delete(string id)
        {

            await productService.Delete(id);



            return RedirectPermanent("/admin/product");
        }
    }
}
