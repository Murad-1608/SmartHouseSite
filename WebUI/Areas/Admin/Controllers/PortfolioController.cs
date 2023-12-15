using Business.Abstract;
using Business.Helper;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolios = await portfolioService.GetAll();

            return View(portfolios);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PortfolioModel model)
        {
            if (!ModelState.IsValid ||
                (model.Photo.ContentType != "image/jpeg" && model.Photo.ContentType != "image/png"))
            {
                return View();
            }
            Portfolio portfolio = new()
            {
                Name = model.Name,
                PhotoUrl = SystemIOOperations.AddPhoto(model.Photo, "Portfolio"),
                Description = model.Description,
                CreatedDate = DateTime.Now
            };

            await portfolioService.Add(portfolio);

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await portfolioService.Delete(id);

            return RedirectToAction("index");
        }
    }
}
