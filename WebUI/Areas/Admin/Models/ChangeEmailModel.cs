using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class ChangeEmailModel
    {
        [Required(ErrorMessage ="Boş keçilə bilməz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string Password { get; set; }
    }
}
