using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Components
{
    public class SocialMediaInFooter : ViewComponent
    {
        private readonly IContactService contactService;

        public SocialMediaInFooter(IContactService contactService)
        {
            this.contactService = contactService;
        }

        public IViewComponentResult Invoke()
        {
            var contact = contactService.Get();

            return View(contact);
        }
    }
}
