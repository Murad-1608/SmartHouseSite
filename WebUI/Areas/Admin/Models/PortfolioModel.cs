using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class PortfolioModel
    {
        [Required(ErrorMessage ="Boş keçilə bilməz")]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public IFormFile Photo { get; set; }
    }
}
