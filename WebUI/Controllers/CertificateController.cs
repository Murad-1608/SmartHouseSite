using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CertificateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
