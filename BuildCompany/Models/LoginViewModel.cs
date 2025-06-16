using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BuildCompany.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [UIHint("password")]
        public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
