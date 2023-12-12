using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.Admin.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage = "Boş keçilə bilməz")]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "Parollar eyni deyildir")]
        public string NewPasswordConfirm { get; set; }
    }
}
