using System.ComponentModel.DataAnnotations;

namespace EticketsWebApp.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Confirm password")]
        [Required(ErrorMessage ="Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Incorrect input")]
        public string ConfirmPassword { get; set; }
    }
}
