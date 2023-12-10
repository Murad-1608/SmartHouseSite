using Microsoft.AspNetCore.Mvc.Rendering;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.ViewModels
{
    public class ProductViewModel
    {
        public ProductModel ProductModel { get; set; }
        public List<SelectListItem>? Categories { get; set; }

    }
}
