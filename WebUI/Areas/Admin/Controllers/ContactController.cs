using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ContactController : Controller
    {
        private readonly IContactService contactService;
        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IActionResult Update()
        {
            var contact = contactService.Get();

            ContactModel model = new()
            {
                Id = contact.Id.ToString(),
                Facebook = contact.Facebook,
                Youtube = contact.Youtube,
                Instagram = contact.Instagram,
                LinkedIn = contact.LinkedIn,
                Telegram = contact.Telegram,
                Tiktok = contact.Tiktok,
                Whatsapp = contact.Whatsapp
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Contact contact = new()
            {
                Id = new Guid(model.Id),
                Facebook = model.Facebook,
                Youtube = model.Youtube,
                Instagram = model.Instagram,
                LinkedIn = model.LinkedIn,
                Telegram = model.Telegram,
                Tiktok = model.Tiktok,
                Whatsapp = model.Whatsapp
            };

            await contactService.Update(contact);

            TempData["SuccessedMessage"] = "Uğurla yeniləndi";

            return View();
        }
    }
}
