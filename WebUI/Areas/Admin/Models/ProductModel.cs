using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class ProductModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "Ad boş keçilə bilməz")]
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required(ErrorMessage = "Şəkil boş keçilə bilməz")]
        public IFormFile BasePhoto { get; set; }
        public List<IFormFile>? PhotoUrls { get; set; }
    }
}
