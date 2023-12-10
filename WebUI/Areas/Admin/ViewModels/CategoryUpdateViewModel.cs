using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.ViewModels
{
    public class CategoryUpdateViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Kateqoriya adı boş keçilə bilməz")]
        public string Name { get; set; }
        public string? Information { get; set; }

    }
}
