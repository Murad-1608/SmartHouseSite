using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.ViewModels;


namespace WebUI.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAll();
            categories.Reverse();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category category = new()
            {
                Name = viewModel.Name,
                Information = viewModel.Information
            };

            await categoryService.Add(category);

            return RedirectPermanent("/admin/category/index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await categoryService.Delete(id);

            TempData["SuccessedMessage"] = "Kateqoriya silindi";

            return RedirectToAction("index");
        }


        public async Task<IActionResult> Update(string id)
        {
            var category = await categoryService.GetById(id);

            CategoryUpdateViewModel viewModel = new()
            {
                Id = category.Id.ToString(),
                Name = category.Name,
                Information = category.Information
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Category category = new()
            {
                Id = new Guid(viewModel.Id),
                Name = viewModel.Name
            };
            await categoryService.Update(category);

            TempData["SuccessedMessage"] = "Uğurla yeniləndi";

            return View();
        }
    }

}
