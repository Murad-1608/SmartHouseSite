using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            this.aboutUsService = aboutUsService;
        }

        public IActionResult Index()
        {
            var value = aboutUsService.GetAbout();

            return View(value);
        }
    }
}
