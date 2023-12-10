using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class PortfolioModel
    {
        [Required(ErrorMessage ="Boş keçilə bilməz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public IFormFile Photo { get; set; }
    }
}
