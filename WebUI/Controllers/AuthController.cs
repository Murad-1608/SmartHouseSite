using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AuthController(UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var hasUser = await userManager.FindByEmailAsync(model.Email);

            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email və ya parol yanlışdır");
                return View();
            }


            var signInResult = await signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, false);

            if (signInResult.Succeeded)
            {
                return RedirectPermanent("/admin/home");
            }

            ModelState.AddModelError(string.Empty, "Email və ya parol yanlışdır");
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();

            return RedirectPermanent("/home/");
        }
    }
}
