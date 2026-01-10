using System.ComponentModel.DataAnnotations;

namespace ShortLink.Client.Data.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email address is requird")]
        [EmailAddress(ErrorMessage ="Invalid email address")]
        [RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Invalid email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is requird")]
        [MinLength(5,ErrorMessage ="Password must be at least 5 characters")]
        public string Password { get; set; }

    }
}
