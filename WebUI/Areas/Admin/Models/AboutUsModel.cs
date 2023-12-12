using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class AboutUsModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Boş keçilə bilməz")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string YoutubeLink { get; set; }
    }
}
