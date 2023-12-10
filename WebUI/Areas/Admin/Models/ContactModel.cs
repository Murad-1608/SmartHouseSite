using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class ContactModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="Boş keçilə bilməz")]
        public string Tiktok { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string LinkedIn { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Telegram { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Whatsapp { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Instagram { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Facebook { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Youtube { get; set; }
    }
}
