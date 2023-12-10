using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Index()
        {
            var contact = contactService.Get();

            return View(contact);
        }
    }
}
