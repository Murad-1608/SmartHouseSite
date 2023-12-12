﻿using Business.Abstract;
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
        public HomeController(ILogger<HomeController> logger,
                              IProductService productService,
                              IPortfolioService portfolioService)
        {
            _logger = logger;
            this.productService = productService;
            this.portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel viewModel = new()
            {
                Products = productService.Last3Product(),
                Portfolio = await portfolioService.GetAll()
            };
            var last3Products = productService.Last3Product();

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