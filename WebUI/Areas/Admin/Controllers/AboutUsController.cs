using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private readonly IAboutUsService aboutUsService;
        public AboutUsController(IAboutUsService aboutUsService)
        {
            this.aboutUsService = aboutUsService;
        }

        public IActionResult Update()
        {
            var aboutUs = aboutUsService.GetAbout();

            AboutUsModel model = new()
            {
                Id = aboutUs.Id.ToString(),
                Text = aboutUs.Text,
                YoutubeLink = aboutUs.YoutubeLink
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUsModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AboutUs about = new()
            {
                Id = new Guid(model.Id),
                Text = model.Text,
                YoutubeLink = model.YoutubeLink
            };
            await aboutUsService.Update(about);

            TempData["SuccessedMessage"] = "Uğurla yeniləndi";

            return View();
        }
    }
}
