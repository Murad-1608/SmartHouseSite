using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class CategoryComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;
        public CategoryComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetAll().Result;

            return View(categories);
        }
    }
}
