using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IPortfolioService portfolioService;
        private readonly IContactService contactService;
        public HomeController(ILogger<HomeController> logger,
                              IProductService productService,
                              IPortfolioService portfolioService,
                              IContactService contactService)
        {
            _logger = logger;
            this.productService = productService;
            this.portfolioService = portfolioService;
            this.contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel viewModel = new()
            {
                Products = productService.Last3Product(),
                Portfolio = await portfolioService.GetAll(),
                Contact = contactService.Get()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}