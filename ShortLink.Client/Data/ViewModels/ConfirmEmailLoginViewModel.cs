using ShortLink.Client.Helpers.Validators;
using System.ComponentModel.DataAnnotations;

namespace ShortLink.Client.Data.ViewModels
{
    public class ConfirmEmailLoginViewModel
    {
        [Required(ErrorMessage ="Email address is requird")]
        [CustomEmailValidator(ErrorMessage ="Email address is not valid (custom)")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is requird")]
        [MinLength(5,ErrorMessage ="Password must be at least 5 characters")]
        public string Password { get; set; }

    }
}
