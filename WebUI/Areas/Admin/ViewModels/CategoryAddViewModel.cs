using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.ViewModels
{
    public class CategoryAddViewModel
    {
        [Required(ErrorMessage ="Kateqoriya adı boş keçilə bilməz")]
        public string Name { get; set; }

        public string? Information { get; set; }
    }
}
