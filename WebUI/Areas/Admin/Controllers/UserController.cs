using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ChangeEmail()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);
            ChangeEmailModel model = new()
            {
                Email = currentUser!.Email!
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailModel model)
        {
            if (!ModelState.IsValid)
                return View();

            var currentUser = await userManager.FindByNameAsync(User.Identity!.Name!);

            bool checkPassword = await userManager.CheckPasswordAsync(currentUser, model.Password);

            if (!checkPassword)
            {
                ModelState.AddModelError(nameof(model.Password), "Parol email'e aid deyildir");
                return View();
            }
            var token = await userManager.GenerateChangeEmailTokenAsync(currentUser, model.Email);

            var result = await userManager.ChangeEmailAsync(currentUser, model.Email, token);

            if (result.Succeeded)
            {
                TempData["SuccessedMessage"] = "Uğurla yeniləndi";
            }
            return View();

        }

    }
}
