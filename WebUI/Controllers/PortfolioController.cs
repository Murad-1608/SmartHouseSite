using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
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

        public async Task<IActionResult> Detail(string id)
        {
            var value = await portfolioService.GetDetail(id);

            return View(value);
        }


    }
}
